using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerIFramesState : State
{
    public PlayerIFramesState(Player owner) : base(owner) { name = "IFrames"; /*name for Debug only*/ }

    private Rigidbody2D rb;
    private Vector2 direction;
    private SpriteManager spritemanager;
    private PlayerValues values;
    private float speedBonus = 3f; // remember to improve this

    public override void Enter()
    {
        rb = owner.GetComponent<Rigidbody2D>();
        values = owner.GetComponent<PlayerValues>();

        spritemanager = owner.GetComponentInChildren<SpriteManager>();
        owner.StartCoroutine(Timer());
        spritemanager.PlayTransparencyEffect(values.InvulnerabilityDuration);
    }

    public override void Execute()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveX, moveY).normalized;

    }

    public override void FixedExecute()
    {
        rb.MovePosition(rb.position + direction * (values.MovementSpeed + speedBonus) * Time.fixedDeltaTime);
    }
    public override void Exit()
    {
        owner.isDamaged = false;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(values.InvulnerabilityDuration);
        if (owner.isDamaged)
        {
            owner.ChangeStates(new PlayerIdleState(owner));
        }
    }
}