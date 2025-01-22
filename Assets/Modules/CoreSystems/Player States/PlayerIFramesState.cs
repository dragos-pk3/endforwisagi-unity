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
    private Camera mainCamera;
    public override void Enter()
    {
        rb = owner.GetComponent<Rigidbody2D>();
        values = owner.GetComponent<PlayerValues>();
        mainCamera = Camera.main;
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
        Vector2 newPosition = rb.position + direction * (values.MovementSpeed + speedBonus) * Time.fixedDeltaTime;

        Vector3 minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        Vector3 maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        newPosition.x = Mathf.Clamp(newPosition.x, minScreenBounds.x, maxScreenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minScreenBounds.y, maxScreenBounds.y);
        rb.MovePosition(newPosition);
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