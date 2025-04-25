using GameLibrary.Enums;
using GameLibrary.Interfaces;
using GameLibrary.Strategies;

namespace GameLibrary.Models.Weapons;

public class Sword : IWeapon
{
    public string Name { get; set; }
    public PositiveInt DamageStat { get; set; }
    public IAttackStrategy AttackStrategy { get; init; }
    public bool IsEquipped { get; set; }
    public WeaponEffects WeaponEffect { get; set; } = WeaponEffects.None;

    public Sword(string name, PositiveInt damageStat, bool isEquipped = false, IAttackStrategy? attackStrategy = null)
    {
        Name = name;
        DamageStat = damageStat;
        IsEquipped = isEquipped;
        AttackStrategy = attackStrategy ?? new MeleeAttackStrategy();
    }
}
