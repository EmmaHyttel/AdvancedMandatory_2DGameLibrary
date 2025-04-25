using GameLibrary.Enums;

namespace GameLibrary.Records;

public record GameConfig
{
    public int MaxX { get; init; }
    public int MaxY { get; init; }
    public GameLevel GameLevel { get; init; }
}
