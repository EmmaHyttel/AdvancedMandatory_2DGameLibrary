using GameLibrary.Models;

namespace GameLibrary.Interfaces;

public interface IAttackStrategy
{
    int CalculateDamage(BaseCreature attacker, BaseCreature defender);
}
