using GameLibrary.Interfaces;
using GameLibrary.Models.Player;

namespace GameLibrary.States;

public class IdleState : IState
{
    public void Enter(Hero hero)
    {
        Console.WriteLine($"{hero.Name} is standing still");
    }

    public void Exit(Hero hero)
    {
        throw new NotImplementedException();
    }

    public void Update(Hero hero)
    {
        throw new NotImplementedException();
    }
}
