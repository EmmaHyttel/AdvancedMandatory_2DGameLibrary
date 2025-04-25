using GameLibrary.Helpers;
using GameLibrary.Models.Weapons;

namespace GameLibrary.Models.Creatures;

public class Troll : BaseCreature
{
    public Troll() : base("Troll", 30, PositionExtensions.GenerateRandomPosition())
    {
        Inventory = [new Bow("Tree Trunk Bow", 10, true), new DefenceItem("Wooden Shield", 5)];
    }
}
