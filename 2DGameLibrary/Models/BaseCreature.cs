using GameLibrary.Enums;
using GameLibrary.Events;
using GameLibrary.Interfaces;
using GameLibrary.Records;
using System.Diagnostics;

namespace GameLibrary.Models;
/// <summary>
/// Base class for all creatures.
/// </summary>
public abstract class BaseCreature : ICreature
{
    /// <summary>
    /// Name of the creature.
    /// </summary>
    public string Name { get; set; }

    public int Health { get; set; }

    public bool IsAlive => Health > 0;

    public Position CurrentPosition { get; set; }

    /// <summary>
    /// Inventory of the creature. Containing List of type IItem, which can be any item using that interface.
    /// </summary>
    public List<IItem> Inventory { get; set; }

    public event EventHandler<CreatureEvent> CreatureEvent;

    /// <summary>
    /// Constructor for the BaseCreature class.
    /// </summary>
    /// <param name="name"> To set the name when instantiating the object </param>
    /// <param name="health"> To set a healt value when instantiating the object </param>
    /// <param name="startposition"> To set the start position of the creature, can use Helper method GenerateRandomPosition() </param>
    public BaseCreature(string name, int health, Position startposition)
    {
        Name = name;
        Health = health;
        CurrentPosition = startposition;
        Inventory = new List<IItem>();
        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 12, $"Creaure with name: {Name} and health: {Health} is created and with position: {CurrentPosition}!");
    }

    /// <summary>
    /// Method to receive damage from another creature.
    /// </summary>
    /// <param name="damageRecieved"> The value of the damage recieved </param>
    /// <param name="creatureHitBy"> The creature from where the hit comes from</param>
    /// <exception cref="ArgumentOutOfRangeException"> Exception for catchin errors </exception>
    public virtual void ReceivedHit(int damageRecieved, BaseCreature creatureHitBy)
    {
        if (damageRecieved < 0)
        {
            throw new ArgumentOutOfRangeException("Damage cannot be negative!");
        }

        Health -= damageRecieved;

        if (!IsAlive)
        {
            MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{Name} has been killed by {creatureHitBy.Name}!");
            CreatureEvent?.Invoke(this, new CreatureEvent(CreatureEventTypes.CreatureKilled));
            return;
        }

        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{Name} received {damageRecieved} damage and has now {Health} health left!");
        CreatureEvent?.Invoke(this, new CreatureEvent(CreatureEventTypes.HitReceived));
    }

    /// <summary>
    /// Method to hit another creature.
    /// Will set a random attack power and a defence power based on the equipped items.
    /// </summary>
    /// <param name="creatureToHit"> The creature the player wishes to hit</param>
    public virtual void Hit(BaseCreature creatureToHit)
    {
        var attackPower = new Random().Next(1, 20);
        var defencePower = creatureToHit.Inventory
            .OfType<DefenceItem>()
            .Sum(x => x.DefenceStat);

        if (attackPower < defencePower)
        {
            MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{Name} tried to hit {creatureToHit.Name} but failed!");
            return;
        }

        var damage = Inventory
              .OfType<IWeapon>()
              .FirstOrDefault(x => x.IsEquipped)?.DamageStat ?? 0;

        var equippedWeapon = GetEquippedWeapon();
        if (equippedWeapon != null)
        {
            damage += equippedWeapon.AttackStrategy.CalculateDamage(this, creatureToHit);
        }

        CreatureEvent?.Invoke(this, new CreatureEvent(CreatureEventTypes.HitDealt));
        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{Name} hit {creatureToHit.Name} for {damage} damage!");

        creatureToHit.ReceivedHit(damage, this);
    }

    /// <summary>
    /// Method for receiving health.
    /// </summary>
    /// <param name="healthReceived"> The value of the health received </param>
    public void ReceiveHealth(int healthReceived)
    {
        Health += healthReceived;
    }

    /// <summary>
    /// Finding the first equipped weapon in the inventory.
    /// </summary>
    /// <returns> Returns the weapon </returns>
    public IWeapon? GetEquippedWeapon()
    {
        return Inventory.FirstOrDefault(x => x is IWeapon w && w.IsEquipped) as IWeapon;
    }

    /// <summary>
    /// Method for looting an object.
    /// </summary>
    /// <param name="someObject"> The object to loot </param>
    /// <exception cref="ArgumentNullException"> If the object has n </exception>
    public void Loot(WorldObject someObject)
    {
        if (someObject == null)
        {
            throw new ArgumentNullException("Object is null!");
        }
        if (someObject.Lootable == true)
        {
            Inventory.AddRange(someObject.Inventory);
            MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 14, $"{Name} looted {someObject.Name}!");
        }
        if (someObject.Removeable == true)
        {
            someObject.Deactivate();
        }
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(Health)}={Health.ToString()}";
    }
}
