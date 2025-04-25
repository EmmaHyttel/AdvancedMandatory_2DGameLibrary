using GameLibrary.Helpers;
using GameLibrary.Models.Weapons;

namespace GameLibrary.Models.Creatures;

public class Orc : BaseCreature
{
    public Orc() : base("Orc", 30, PositionExtensions.GenerateRandomPosition())
    {
        Inventory = [new Sword("Orc Sword", 10, true), new DefenceItem("Wooden Shield", 5)];
    }
}
