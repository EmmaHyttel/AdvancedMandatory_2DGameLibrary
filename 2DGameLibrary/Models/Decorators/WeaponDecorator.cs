using GameLibrary.Enums;
using GameLibrary.Interfaces;

namespace GameLibrary.Models.Decorators;

public abstract class WeaponDecorator : IWeapon
{
    private readonly IWeapon _wrappedWeapon;

    public WeaponDecorator(IWeapon wrappedWeapon)
    {
        _wrappedWeapon = wrappedWeapon;
    }

    public virtual PositiveInt DamageStat
    {
        get => _wrappedWeapon.DamageStat;
        set => _wrappedWeapon.DamageStat = value;
    }

    public virtual bool IsEquipped
    {
        get => _wrappedWeapon.IsEquipped;
        set => _wrappedWeapon.IsEquipped = value;
    }

    public IAttackStrategy AttackStrategy => _wrappedWeapon.AttackStrategy;

    public string Name
    {
        get => _wrappedWeapon.Name;
        set => _wrappedWeapon.Name = value;
    }

    public WeaponEffects WeaponEffect
    {
        get => _wrappedWeapon.WeaponEffect;
        set => _wrappedWeapon.WeaponEffect = value;
    }
}
