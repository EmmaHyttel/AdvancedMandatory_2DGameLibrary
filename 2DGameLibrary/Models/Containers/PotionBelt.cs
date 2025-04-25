using GameLibrary.Interfaces;

namespace GameLibrary.Models.Containers;

public class PotionBelt : BaseContainer
{
    public PotionBelt() : base("Potion Belt", 5)
    {
    }

    public override bool AddItem(IItem item)
    {
        if (item is not IPotion)
        {
            return false;
        }

        return base.AddItem(item);
    }
}
