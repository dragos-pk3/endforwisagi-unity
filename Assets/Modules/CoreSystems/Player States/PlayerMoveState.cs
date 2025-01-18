using System.Linq.Expressions;
using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(GameObject owner) : base(owner) { name = "MOVE"; /*name for Debug only*/ }

    private Rigidbody2D rb;
    private Vector2 direction;

    public override void Enter()
    {
        rb = owner.GetComponent<Rigidbody2D>();
    }

    public override void Execute()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveX, moveY).normalized;
       
    }

    public override void FixedExecute()
    {
        rb.MovePosition(rb.position + direction * owner.GetComponent<Player>().PlayerData.BaseMovementSpeed.BaseValue * Time.fixedDeltaTime);
    }
    public override void Exit()
    {
        Debug.Log($"Exiting {name}");
    }
}