using GameLibrary.Helpers;
using GameLibrary.Interfaces;
using GameLibrary.Models;
using GameLibrary.Models.Player;
using GameLibrary.Records;
using System.Diagnostics;

namespace GameLibrary.States;

public class MovingUp : IState
{
    private Position target;
    private bool canMove;

    public void Enter(Hero hero)
    {
        target = hero.CurrentPosition.Apply(Moves.Up);

        if (World.IsOccupied(target))
        {
            Console.WriteLine($"There is a creature on {target}");
            canMove = false; // ikke sikker på det skal gøres sådan her ellers skal man i hvert fald kunne vælge at angribe 
        }
        else
        {
            canMove = true;
        }
    }

    public void Exit(Hero hero)
    {
        MyLogger.Instance.tc.TraceEvent(TraceEventType.Information, 13, $"{hero.Name}'s current position is {hero.CurrentPosition}");
    }

    public void Update(Hero hero)
    {
        if (canMove)
        {
            hero.CurrentPosition = target;
            Console.WriteLine($"Moved to {target}");
        }

        hero.ChangeState(new IdleState());
    }


    //public Move NextMove(InputType input)
    //{
    //    switch (input)
    //    {
    //        case InputType.forward: return new Move(1, 0);
    //        case InputType.left: return new Move(0, 1);
    //        case InputType.right: return new Move(0, -1);
    //        default: return new Move(0, 0);
    //    }
    //}

    //public IState NewState(InputType input)
    //{
    //    switch (input)
    //    {
    //        case InputType.forward: return new MovingDown();
    //        case InputType.left: return new MovingRight();
    //        case InputType.right: return new MovingUp();
    //        default: return new MovingDown();
    //    }
    //}
}
