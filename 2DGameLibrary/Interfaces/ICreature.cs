using GameLibrary.Models;
using GameLibrary.Records;

namespace GameLibrary.Interfaces;

public interface ICreature
{
    string Name { get; set; }

    int Health { get; set; }

    Position CurrentPosition { get; set; }

    public bool IsAlive => Health > 0;

    void Hit(BaseCreature creatureToHit);

    void ReceivedHit(int damageRecieved, BaseCreature creatureHitBy);

    void ReceiveHealth(int health);

    void Loot(WorldObject someObject);
}
