using GameLibrary.Enums;
using GameLibrary.Interfaces;

namespace GameLibrary.Models.Decorators;

public class PoisionWeaponDecorator : WeaponDecorator
{
    public PoisionWeaponDecorator(IWeapon wrappedWeapon) : base(wrappedWeapon)
    {
        WeaponEffect = WeaponEffects.Poisoned;
    }
}
