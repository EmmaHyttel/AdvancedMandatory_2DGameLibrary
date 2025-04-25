using GameLibrary.Interfaces;
using GameLibrary.Models;
using System.Diagnostics;

namespace GameLibrary.Strategies;

public class MagicAttackStrategy : IAttackStrategy
{
    public int CalculateDamage(BaseCreature attacker, BaseCreature defender)
    {
        var attackerWeapon = attacker.GetEquippedWeapon();
        var defenderWeapon = defender.GetEquippedWeapon();

        if (defenderWeapon != null && defenderWeapon.AttackStrategy is MeleeAttackStrategy)
        {
            if (attackerWeapon != null)
            {
                MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{attacker.Name}'s magic combat style has advantage over {defender.Name}'s melee combat style \nHe deals more damage!");
                return 5;
            }
        }

        return 0;
    }
}
