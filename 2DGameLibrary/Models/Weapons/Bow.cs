using GameLibrary.Enums;
using GameLibrary.Interfaces;
using GameLibrary.Strategies;

namespace GameLibrary.Models.Weapons;

public class Bow : IWeapon
{
    public PositiveInt DamageStat { get; set; }

    public bool IsEquipped { get; set; }

    public IAttackStrategy AttackStrategy { get; init; }

    public string Name { get; set; }

    public WeaponEffects WeaponEffect { get; set; } = WeaponEffects.None;

    public Bow(string name, PositiveInt damageStat, bool isEquipped = false)
    {
        Name = name;
        DamageStat = damageStat;
        IsEquipped = isEquipped;
        AttackStrategy = new RangedAttackStrategy();
    }
}
