using GameLibrary.Models;

namespace GameLibrary.Interfaces;

public interface IDefenceItem : IItem
{
    PositiveInt DefenceStat { get; set; }
}
