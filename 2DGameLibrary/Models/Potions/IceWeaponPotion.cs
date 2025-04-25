using GameLibrary.Enums;
using GameLibrary.Interfaces;
using GameLibrary.Models.Decorators;
using System.Diagnostics;

namespace GameLibrary.Models.Potions;

public class IceWeaponPotion : IPotion
{
    public int MaxDoses { get; init; } = 1;
    public int CurrentDoses { get; set; } = 1;
    public PotionTypes PotionType { get; init; } = PotionTypes.WeaponIce;
    public string Name { get; set; } = "Ice Weapon Potion";

    public IWeapon UsePotion(IWeapon weapon)
    {
        if (CurrentDoses <= 0)
        {
            MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 12, $"Could not apply {Name} to {weapon.Name}, because there are no more doses.");
            return weapon;
        }

        CurrentDoses--;
        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 12, $"{Name} has been applied to {weapon.Name}.");
        return new FrozenWeaponDecorator(weapon);
    }
}
