using GameLibrary.Models;
using GameLibrary.Records;

namespace GameLibrary.Helpers;

public static class PositionExtensions
{
    public static Position Apply(this Position position, Move move) =>
    new(position.row + move.row, position.col + move.col);

    public static Position GenerateRandomPosition()
    {
        var random = new Random();
        var position = new Position(random.Next(1, World.MaxX + 1), random.Next(1, World.MaxY + 1));

        var isOccupied = World.IsOccupied(position);

        while (isOccupied)
        {
            position = new Position(random.Next(1, World.MaxX + 1), random.Next(1, World.MaxY + 1));
            isOccupied = World.IsOccupied(position);
        }

        return position;
    }
}
