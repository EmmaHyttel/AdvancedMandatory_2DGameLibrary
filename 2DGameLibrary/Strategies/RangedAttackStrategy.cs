using GameLibrary.Interfaces;
using GameLibrary.Models;
using System.Diagnostics;

namespace GameLibrary.Strategies;

public class RangedAttackStrategy : IAttackStrategy
{
    public int CalculateDamage(BaseCreature attacker, BaseCreature defender)
    {
        var attackerWeapon = attacker.GetEquippedWeapon();
        var defenderWeapon = defender.GetEquippedWeapon();

        if (defenderWeapon != null && defenderWeapon.AttackStrategy is MagicAttackStrategy)
        {
            if (attackerWeapon != null)
            {
                MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{attacker.Name}'s ranged combat style has advantage over {defender.Name}'s magic combat style \nHe deals more damage!");
                return 5;
            }
        }

        return 0;
    }
}
