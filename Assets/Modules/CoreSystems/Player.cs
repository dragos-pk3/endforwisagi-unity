
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Player : Entity
{
    public BasePlayerData PlayerData = new BasePlayerData();
    // load selectedclass
    // add state machine
    // add player controler 
    // load apply class modifiers
    // load class abilities 
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int LevelCap { get; private set; }
    public int StatCap { get; private set; }
    public int StatPoints { get; private set; }
    public int MaxHealth { get; set; }
    [SerializeField] public int CurrentHealth;
    public float DamageResistance { get; set; }
    public int Damage { get; set; }
    public float Knockback { get; set; }
    public int MaxMana { get; set; }
    public int CurrentMana { get; set; }
    public float ManaRechargeDelay { get; set; }
    public int ManaRechargeRate { get; set; }
    public float MoveSpeed { get; set; }
    public float StunDuration { get; set; }
    public float InvulnerableDuration { get; set; }
    public bool isDamaged = false;
    [SerializeField] public PlayerClass SelectedClass;

    StateMachine StateMachine = new StateMachine();

    Dictionary<string, State> States = new Dictionary<string, State>();
    [SerializeField]
    public string CurrentStateString; // Just for debugging

    public State CurrentState;
    public void Start()
    {
        MaxHealth = 20;
        StunDuration = 2f;
        InvulnerableDuration = 1f;
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        PopulateStates();
        EventManager.PlayerClassSelection(SelectedClass);
        GetCurrentState(); // Debug Line
        Debug.Log(DictToString(States));
        

    }

    public void OnEnable()
    {
        EventManager.OnPlayerStatChange += UpdateStats; // Call EventManager.PlayerStatChange() to update Stats
        EventManager.OnPlayerDamaged += TakeDamage;
    }

    public void OnDisable()
    {
        EventManager.OnPlayerStatChange -= UpdateStats;
        EventManager.OnPlayerDamaged -= TakeDamage;

    }

    private void TakeDamage(int damage)
    {
        if (!isDamaged)
        {
            if (CurrentHealth > 0)
            {
                CurrentHealth -= damage;
                StateMachine.ChangeState(States["DAMAGED"]);
            }
            else
            {
                CurrentHealth = 0;
                StateMachine.ChangeState(States["DEATH"]);
            }
        }
    }

    private void UpdateStats()
    {
        //TODO Fix Value type mismatch
        //MaxHealth = PlayerData.BaseHealth.BaseValue + PlayerData.stats[StatType.Endurance] * PlayerData.BaseHealth.Multiplier;
        //Damage = PlayerData.BaseAttack.BaseValue + PlayerData.stats[StatType.Force] * PlayerData.BaseAttack.Multiplier;
        //Knockback = PlayerData.BaseKnockback.BaseValue + PlayerData.stats[StatType.Force] * PlayerData.BaseKnockback.Multiplier;
        //MaxMana = PlayerData.BaseMana.BaseValue + PlayerData.stats[StatType.Wisdom] * PlayerData.BaseMana.Multiplier;
        //ManaRechargeDelay = PlayerData.BaseManaRechargeDelay.BaseValue + PlayerData.stats[StatType.Wisdom] * PlayerData.BaseManaRechargeDelay.Multiplier;
        //ManaRechargeRate = PlayerData.BaseManaRechargeRate.BaseValue + PlayerData.stats[StatType.Wisdom] * PlayerData.BaseManaRechargeRate.Multiplier;
        MoveSpeed = PlayerData.BaseMovementSpeed.BaseValue + PlayerData.stats[StatType.Agility] * PlayerData.BaseMovementSpeed.Multiplier;
        //StunDuration = PlayerData.BaseStunDuration.BaseValue - PlayerData.stats[StatType.Agility] * PlayerData.BaseStunDuration.Multiplier;
        //InvulnerableDuration = PlayerData.BaseInvulnerableDuration.BaseValue + PlayerData.stats[StatType.Agility] * PlayerData.BaseInvulnerableDuration.Multiplier;
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
        //States.Add("Invulnerable", new PlayerInvulnerableState(gameObject));
        //States.Add("Death", new PlayerDeathState(gameObject));
        StateMachine.ChangeState(States["IDLE"]);
    }

    private void Update()
    {
        if (CurrentState != StateMachine.CurrentState) GetCurrentState();
        if (CurrentState == States["DAMAGED"]) return;
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            StateMachine.ChangeState(States["IDLE"]);
        }
        else
        {
            StateMachine.ChangeState(States["MOVE"]);
        }
        StateMachine.Update();
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


}