using GameLibrary.Enums;
using GameLibrary.Models;

namespace GameLibrary.Interfaces;

public interface ICreatureFactory
{
    BaseCreature Create(Creatures creature);
}
