using GameLibrary.Interfaces;

namespace GameLibrary.Models;

public class DefenceItem : IDefenceItem
{
    public string Name { get; set; }

    public PositiveInt DefenceStat { get; set; }

    public DefenceItem(string name, PositiveInt defenceStat)
    {
        Name = name;
        DefenceStat = defenceStat;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(DefenceStat)}={DefenceStat.ToString()}}}";
    }
}
