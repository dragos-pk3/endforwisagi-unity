
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
public class Player : Entity
{
    [SerializeField] public PlayerClass selectedClass = PlayerClass.Ninja;
    Rigidbody2D rb;
    StateMachine StateMachine = new StateMachine();
    public WeaponBehaviour Weapon;
    Dictionary<string, State> States = new Dictionary<string, State>();
    [SerializeField]
    public string CurrentStateString; // Just for debugging
    public bool isDamaged = false;
    public bool canMove = true;
    public State CurrentState;
    public Vector2 lastDirection;
    private float dashDistance = 3f;
    private Vector3 dashDirection;
    Vector3 newPosition;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Weapon = FindFirstObjectByType<WeaponBehaviour>();
        PopulateStates();
        EventManager.PlayerClassSelection(selectedClass);
    }

    public void OnEnable()
    {
        EventManager.OnPlayerDamaged += PlayerDamaged;
        EventManager.OnPlayerDefeated += PlayerDeath;
        EventManager.OnPlayerMoveInput += PlayerMove;
        EventManager.OnPlayerIdleInput += PlayerIdle;
        EventManager.OnPlayerDashing += PlayerDash;
    }

    public void OnDisable()
    {
        EventManager.OnPlayerDamaged -= PlayerDamaged;
        EventManager.OnPlayerDefeated -= PlayerDeath;
        EventManager.OnPlayerMoveInput -= PlayerMove;
        EventManager.OnPlayerIdleInput -= PlayerIdle;
        EventManager.OnPlayerDashing -= PlayerDash;

    }

    public void ChangeStates(State state) { StateMachine.ChangeState(state); }
    public void GetCurrentState() { CurrentState = StateMachine.CurrentState; CurrentStateString = StateMachine.CurrentState.name; } // Just for debugging
    public void PopulateStates()
    {
        States.Add("IDLE", new PlayerIdleState(this));
        States.Add("MOVE", new PlayerMoveState(this));
        States.Add("DAMAGED", new PlayerDamagedState(this));
        States.Add("DEATH", new PlayerDeathState(this));
        States.Add("DASH", new PlayerDashState(this));
        States.Add("IFRAMES", new PlayerIFramesState(this));
        StateMachine.ChangeState(States["IDLE"]);
    }

    private void Update()
    {
        if (CurrentState != StateMachine.CurrentState) GetCurrentState();

        StateMachine.Update();

    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }

    private void PlayerDamaged(int damage)
    {
        if (!isDamaged)
        {
            StateMachine.ChangeState(States["DAMAGED"]);
            EventManager.PlayerDecreaseHealth(damage);
        }
    }

    private void PlayerDeath()
    {
        StateMachine.ChangeState(States["DEATH"]);
    }
    private void PlayerMove()
    {
        if(!isDamaged && canMove) StateMachine.ChangeState(States["MOVE"]);
    }
    private void PlayerIdle()
    {
        if(!isDamaged) StateMachine.ChangeState(States["IDLE"]);
    }
    private void PlayerDash()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 direction = (moveX == 0 && moveY == 0) ? new Vector2(1,0) : new Vector2(moveX, moveY).normalized;

        StateMachine.ChangeState(States["DASH"]);
        StartCoroutine(DashCoroutine(direction));
    }
    public IEnumerator DashCoroutine(Vector2 dir)
    {
        canMove = false;
        float elapsed = 0f;
        Vector2 dashPosition = rb.position + dir * dashDistance;
        float duration = 0.3f;
        Camera mainCamera = Camera.main;

        Vector3 minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        Vector3 maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        dashPosition.x = Mathf.Clamp(dashPosition.x, minScreenBounds.x, maxScreenBounds.x);
        dashPosition.y = Mathf.Clamp(dashPosition.y, minScreenBounds.y, maxScreenBounds.y);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            rb.MovePosition(Vector2.Lerp(rb.position, dashPosition, elapsed / duration));
            yield return null;
        }
        canMove = true;
        StateMachine.ChangeState(States["IDLE"]);
    }
}