using System.Linq.Expressions;
using UnityEngine;

public class PlayerIdleState : State
{
    public PlayerIdleState(Player owner) : base(owner) { name = "IDLE"; /*name for Debug only*/}
    public override void Enter()
    {

    }
    public override void Execute()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    owner.GetComponent<PlayerStateManager>().ChangeState(new PlayerMoveState(owner)); // will need to queue actions or events to access ChangeState 
        //}
    }

    public override void Exit()
    {

    }
}