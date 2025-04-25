using GameLibrary.Enums;
using GameLibrary.Interfaces;
using System.Diagnostics;

namespace GameLibrary.Models.Potions;

public class HealthPotion : ICreaturePotion
{
    public int MaxDoses { get; init; } = 4;
    public int CurrentDoses { get; set; } = 4;
    public PotionTypes PotionType { get; init; } = PotionTypes.Healing;
    public string Name { get; set; } = "Health Potion";
    public int Amount { get; set; } = 10;

    public void UsePotion(BaseCreature target)
    {
        if (CurrentDoses <= 0)
        {
            MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 12, $"Could not apply {Name} to target, because there are no more doses.");
            return;
        }

        target.ReceiveHealth(Amount);
        CurrentDoses--;
        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 12, $"{Name} with {Amount} has been applied to {target.Name}");
    }
}
