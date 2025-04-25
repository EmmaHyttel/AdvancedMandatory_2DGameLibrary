using GameLibrary.Enums;
using GameLibrary.Interfaces;

namespace GameLibrary.Models.Decorators;

public class FlamingWeaponDecorator : WeaponDecorator
{
    public FlamingWeaponDecorator(IWeapon wrappedWeapon) : base(wrappedWeapon)
    {
        WeaponEffect = WeaponEffects.Flaming;
    }
}
