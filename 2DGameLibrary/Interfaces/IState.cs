using GameLibrary.Models.Player;

namespace GameLibrary.Interfaces;

public interface IState
{
    void Enter(Hero hero);
    void Update(Hero hero);
    void Exit(Hero hero);

}
