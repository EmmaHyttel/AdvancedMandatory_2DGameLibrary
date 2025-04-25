using GameLibrary.Interfaces;
using GameLibrary.Records;

namespace GameLibrary.Models;

public class WorldObject
{
    public string Name { get; set; }

    public Position CurrentPosition { get; set; }

    public bool Lootable { get; set; }

    public bool Removeable { get; set; }

    public bool IsRemoved { get; private set; } = false;

    public List<IItem> Inventory { get; set; } // skal gøre det muligt både at være attack og defense item 

    public WorldObject(string name, bool lootable, bool removeable)
    {
        Name = name;
        Lootable = lootable;
        Removeable = removeable;
        Inventory = new List<IItem>();
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(Lootable)}={Lootable.ToString()}, {nameof(Removeable)}={Removeable.ToString()}}}";
    }

    public void Deactivate()
    {
        if (Removeable)
        {
            IsRemoved = true;
        }
    }

    public void AddItem(IItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item is null!");
        }
        Inventory.Add(item);
    }
}
