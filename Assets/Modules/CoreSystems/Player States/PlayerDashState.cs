using System.Collections;
using System.Linq.Expressions;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerDashState : State
{
    public PlayerDashState(Player owner) : base(owner) { name = "DASH"; /*name for Debug only*/ }

    private Rigidbody2D rb;
    private Vector2 direction;
    private PlayerValues values;
    private Camera mainCamera;
    private float dashDistance = 5f;
    private Vector2 dashPosition;
    private float tolerance = 0.1f;

    public override void Enter()
    {
        //rb = owner.GetComponent<Rigidbody2D>();
        //values = owner.GetComponent<PlayerValues>();
        //mainCamera = Camera.main;
        //dashPosition = rb.position + direction * dashDistance;

    }

    public override void Execute()
    {
        //float moveX = Input.GetAxisRaw("Horizontal");
        //float moveY = Input.GetAxisRaw("Vertical");
        //direction = new Vector2(moveX, moveY).normalized;

    }

    public override void FixedExecute()
    {
    }

    public override void Exit()
    {

    }

 
}