
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
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
    public State CurrentState;

    private float dashDistance = 3f;
    private Vector3 dashDirection;
    Vector3 newPosition;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Weapon = FindFirstObjectByType<WeaponBehaviour>();
        PopulateStates();
        Debug.Log(DictToString(States));
        EventManager.PlayerClassSelection(selectedClass);
    }

    public void OnEnable()
    {
        EventManager.OnPlayerDamaged += PlayerDamaged;
        EventManager.OnPlayerDefeated += PlayerDeath;
        EventManager.OnPlayerMoveInput += PlayerMove;
        EventManager.OnPlayerIdleInput += PlayerIdle;
        EventManager.OnPlayerDashing += Dash;
    }

    public void OnDisable()
    {
        EventManager.OnPlayerDamaged -= PlayerDamaged;
        EventManager.OnPlayerDefeated -= PlayerDeath;
        EventManager.OnPlayerMoveInput -= PlayerMove;
        EventManager.OnPlayerIdleInput -= PlayerIdle;
        EventManager.OnPlayerDashing -= Dash;

    }

    private void Dash(float dashDistance)
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Camera mainCamera = Camera.main;
        Vector2 direction = new Vector2(moveX, moveY).normalized;
        // Calculate the new position based on the dash distance and current direction
        Vector2 dashPosition = rb.position + direction * dashDistance;

        // Clamp the position to ensure it stays within screen bounds
        Vector3 minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        Vector3 maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        dashPosition.x = Mathf.Clamp(dashPosition.x, minScreenBounds.x, maxScreenBounds.x);
        dashPosition.y = Mathf.Clamp(dashPosition.y, minScreenBounds.y, maxScreenBounds.y);

        // Move the player directly to the new position
        rb.MovePosition(dashPosition);
    }
    public void ChangeStates(State state) { StateMachine.ChangeState(state); }
    public void GetCurrentState() { CurrentState = StateMachine.CurrentState; CurrentStateString = StateMachine.CurrentState.name; } // Just for debugging
    public void PopulateStates()
    {
        States.Add("IDLE", new PlayerIdleState(this));
        States.Add("MOVE", new PlayerMoveState(this));
        States.Add("DAMAGED", new PlayerDamagedState(this));
        States.Add("DEATH", new PlayerDeathState(this));
        //States.Add("UseAbility", new PlayerAttackState(gameObject));
        States.Add("IFRAMES", new PlayerIFramesState(this));
        StateMachine.ChangeState(States["IDLE"]);
    }

    private void Update()
    {
        if (CurrentState != StateMachine.CurrentState) GetCurrentState();
        //if ((Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 ) && !isDamaged)
        //{
        //     StateMachine.ChangeState(States["IDLE"]);
        //}
        //if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !isDamaged)
        //{
        //    StateMachine.ChangeState(States["MOVE"]);
        //}
        StateMachine.Update();
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    EventManager.CreateClones();

        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Weapon.DestroyClones();
        //}
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }

    public string DictToString(Dictionary<string, State> dict)
    {
        string output = "";
        foreach (KeyValuePair<string, State> kvp in dict)
        {
            string key = kvp.Key;
            object value = kvp.Value;
            string pair = key + ": " + value.ToString() + "\n";
            output += pair;
        }
        return output;
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
        if(!isDamaged) StateMachine.ChangeState(States["MOVE"]);
    }
    private void PlayerIdle()
    {
        if(!isDamaged) StateMachine.ChangeState(States["IDLE"]);
    }
}