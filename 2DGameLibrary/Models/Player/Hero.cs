using GameLibrary.Interfaces;
using GameLibrary.Models.Weapons;
using GameLibrary.Records;

namespace GameLibrary.Models.Player;

public class Hero : BaseCreature
{
    public IState CurrentState { get; private set; }

    public Hero(string name, int health, Position startposition) : base(name, health, startposition)
    {
        Inventory.Add(new Sword("Bronze Sword", 10, true));
        Inventory.Add(new DefenceItem("Íron Shield", 10));
    }

    public void ChangeState(IState newState)
    {
        CurrentState?.Exit(this);
        CurrentState = newState;
        CurrentState.Enter(this);
    }

    public void Update()
    {
        CurrentState?.Update(this);
    }
}

