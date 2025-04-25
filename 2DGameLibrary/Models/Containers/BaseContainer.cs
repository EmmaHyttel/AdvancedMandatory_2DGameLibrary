using GameLibrary.Interfaces;

namespace GameLibrary.Models.Containers;

public abstract class BaseContainer : IItem
{
    public string Name { get; set; }

    public int MaxCapacity { get; set; }

    public List<IItem> Items { get; set; } = [];

    public BaseContainer(string name, int maxCapacity)
    {
        Name = name;
        MaxCapacity = maxCapacity;
    }

    public virtual bool AddItem(IItem item)
    {
        if (Items.Count >= MaxCapacity)
        {
            return false;
        }

        Items.Add(item);

        return true;
    }
}
