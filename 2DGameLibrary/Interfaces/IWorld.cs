using GameLibrary.Models;
using GameLibrary.Records;

namespace GameLibrary.Interfaces;

public interface IWorld
{
    int MaxX { get; set; }
    int MaxY { get; set; }
    string Name { get; set; }
    List<BaseCreature> Creatures { get; set; }
    bool IsOccupied(Position position);
    BaseCreature GetCreatureAt(Position position);
}
