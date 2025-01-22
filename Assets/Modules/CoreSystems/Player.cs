
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Player : Entity
{
    
    BaseSpells Spells;
    StateMachine StateMachine = new StateMachine();
    public WeaponBehaviour Weapon;
    Dictionary<string, State> States = new Dictionary<string, State>();
    [SerializeField]
    public string CurrentStateString; // Just for debugging
    public bool isDamaged = false;
    public State CurrentState;
    public void Start()
    {
        Spells = GetComponent<BaseSpells>();
        Weapon = FindFirstObjectByType<WeaponBehaviour>();
        PopulateStates();
        Debug.Log(DictToString(States));
    }

    public void OnEnable()
    {
        EventManager.OnPlayerDamaged += PlayerDamaged;
        EventManager.OnPlayerDefeated += PlayerDeath;
    }

    public void OnDisable()
    {
        EventManager.OnPlayerDamaged -= PlayerDamaged;
        EventManager.OnPlayerDefeated -= PlayerDeath;
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
        //States.Add("Stun", new PlayerStunState(gameObject));
        States.Add("IFRAMES", new PlayerIFramesState(this));
        //States.Add("Death", new PlayerDeathState(gameObject));
        StateMachine.ChangeState(States["IDLE"]);
    }

    private void Update()
    {
        if (CurrentState != StateMachine.CurrentState) GetCurrentState();
        if ((Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 ) && !isDamaged)
        {
             StateMachine.ChangeState(States["IDLE"]);
        }
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !isDamaged)
        {
            StateMachine.ChangeState(States["MOVE"]);
        }
        StateMachine.Update();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.CreateClones();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Weapon.DestroyClones();
        }
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

}