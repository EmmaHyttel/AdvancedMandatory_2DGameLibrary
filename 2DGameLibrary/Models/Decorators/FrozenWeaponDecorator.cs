using GameLibrary.Enums;
using GameLibrary.Interfaces;

namespace GameLibrary.Models.Decorators;

public class FrozenWeaponDecorator : WeaponDecorator
{
    public FrozenWeaponDecorator(IWeapon wrappedWeapon) : base(wrappedWeapon)
    {
        WeaponEffect = WeaponEffects.Frozen;
    }
}
