using GameLibrary.Enums;
using GameLibrary.Helpers;
using GameLibrary.Interfaces;
using GameLibrary.Records;
using System.Diagnostics;

namespace GameLibrary.Models;

public static class World
{
    public static int MaxX { get; set; }

    public static int MaxY { get; set; }

    public static GameLevel GameLevel { get; set; }

    public static List<BaseCreature> Creatures { get; set; } = [];

    public static string Name { get; set; }

    //public override string ToString()
    //{
    //    return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}, {nameof(Creatures)}={Creatures}}}";
    //}

    public static void Initialize(string name)
    {
        Name = name;

        var gameConfig = GameConfigHelper.GetGameConfig();
        MaxX = gameConfig.MaxX;
        MaxY = gameConfig.MaxY;
        GameLevel = gameConfig.GameLevel;

        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 15, $"World object: {Name} is created");
    }

    public static bool IsOccupied(Position position)
    {
        return Creatures.Any(creature => creature.CurrentPosition.Equals(position));
    }

    public static BaseCreature GetCreatureAt(Position position)
    {
        throw new NotImplementedException();
    }
}
