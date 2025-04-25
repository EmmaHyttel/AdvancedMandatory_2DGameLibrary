using GameLibrary.Enums;
using GameLibrary.Models;

namespace GameLibrary.Interfaces;

public interface IWeapon : IItem
{
    PositiveInt DamageStat { get; set; }
    bool IsEquipped { get; set; }
    IAttackStrategy AttackStrategy { get; }
    WeaponEffects WeaponEffect { get; set; }
}
