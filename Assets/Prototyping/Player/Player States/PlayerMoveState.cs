using System.Linq.Expressions;
using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(GameObject owner) : base(owner) { name = "MOVE"; /*name for Debug only*/ }

    private Rigidbody2D rb;
    private Vector2 movement;

    public override void Enter()
    {
        rb = owner.GetComponent<Rigidbody2D>();
        Debug.Log($"Entering {name}");
    }

    public override void Execute()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
       
    }

    public override void FixedExecute()
    {
        rb.MovePosition(rb.position + movement * owner.GetComponent<PlayerStatsHandler>().MovementSpeed * Time.fixedDeltaTime);
    }
    public override void Exit()
    {
        // Exit
        Debug.Log($"Exiting {name}");
    }
}