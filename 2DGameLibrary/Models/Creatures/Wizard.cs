using GameLibrary.Helpers;
using GameLibrary.Models.Weapons;

namespace GameLibrary.Models.Creatures;

public class Wizard : BaseCreature
{
    public Wizard() : base("Wizard", 50, PositionExtensions.GenerateRandomPosition())
    {
        Inventory = [new MagicStaff("Oak Staff", GenerateSpellDamage(), true), new DefenceItem("Magic Shield", 15)];
    }

    private static int GenerateSpellDamage()
    {
        var random = new Random();
        return random.Next(15, 30);
    }
}
