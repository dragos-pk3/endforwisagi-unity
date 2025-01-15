using System.Linq.Expressions;
using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(GameObject owner) : base(owner) { name = "MOVE"; /*name for Debug only*/ }


    public override void Enter()
    {
        // Enter 
    }

    public override void Execute()
    {
        var rb = owner.GetComponent<Rigidbody>();
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        var movement = new Vector2(moveX, moveY).normalized;
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
       
        if(!Input.GetKey(KeyCode.W)) owner.GetComponent<PlayerStateManager>().ChangeState(new PlayerIdleState(owner));
    }
 
    public override void Exit()
    {
        // Exit
        Debug.Log($"Exiting {name}");
    }
}