using System.Linq.Expressions;
using UnityEngine;

public class PlayerDeathState : State
{
    public PlayerDeathState(Player owner) : base(owner) { name = "DEATH"; /*name for Debug only*/}
    public override void Enter()
    {
        owner.DestroyEntity();
    }
    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}