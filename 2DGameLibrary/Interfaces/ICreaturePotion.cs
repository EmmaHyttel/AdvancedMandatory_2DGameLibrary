using GameLibrary.Models;

namespace GameLibrary.Interfaces;

public interface ICreaturePotion : IPotion
{
    int Amount { get; set; }
    void UsePotion(BaseCreature target);
}
