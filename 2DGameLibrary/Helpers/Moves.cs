using GameLibrary.Records;

namespace GameLibrary.Helpers;

public static class Moves
{
    public static readonly Move Up = new(-1, 0);
    public static readonly Move Down = new(1, 0);
    public static readonly Move Left = new(0, -1);
    public static readonly Move Right = new(0, 1);
}
