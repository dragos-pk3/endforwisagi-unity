using System.Linq.Expressions;
using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(Player owner) : base(owner) { name = "MOVE"; /*name for Debug only*/ }

    private Rigidbody2D rb;
    private Vector2 direction;
    private PlayerValues values;
    private Camera mainCamera;
    float moveX;
    float moveY;

    public override void Enter()
    {
        rb = owner.GetComponent<Rigidbody2D>();
        values = owner.GetComponent<PlayerValues>();
        mainCamera = Camera.main;
    }

    public override void Execute()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveX, moveY).normalized;
    }

    public override void FixedExecute()
    {
        Vector2 newPosition = rb.position + direction * values.MovementSpeed * Time.fixedDeltaTime;

        Vector3 minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        Vector3 maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        newPosition.x = Mathf.Clamp(newPosition.x, minScreenBounds.x, maxScreenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minScreenBounds.y, maxScreenBounds.y);
        rb.MovePosition(newPosition);
    }

    public override void Exit()
    {
    }
}