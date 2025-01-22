using System.Linq.Expressions;
using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(Player owner) : base(owner) { name = "MOVE"; /*name for Debug only*/ }

    private Rigidbody2D rb;
    private Vector2 direction;
    private PlayerValues values;

    public override void Enter()
    {
        rb = owner.GetComponent<Rigidbody2D>();
        values = owner.GetComponent<PlayerValues>();
    }

    public override void Execute()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveX, moveY).normalized;
    }

    public override void FixedExecute()
    {
        rb.MovePosition(rb.position + direction * values.MovementSpeed * Time.fixedDeltaTime);
    }
    public override void Exit()
    {

    }
}