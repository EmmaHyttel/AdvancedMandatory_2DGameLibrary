using GameLibrary.Enums;
using GameLibrary.Interfaces;
using GameLibrary.Models;
using GameLibrary.Models.Creatures;

namespace GameLibrary.Factories;

public class CreatureFactory : ICreatureFactory
{
    public BaseCreature Create(Creatures creature)
    {
        return creature switch
        {
            Creatures.Orc => new Orc(),
            Creatures.Wizard => new Wizard(),
            Creatures.Troll => new Troll(),
            _ => throw new ArgumentOutOfRangeException(nameof(creature), creature, null)
        };
    }
}
