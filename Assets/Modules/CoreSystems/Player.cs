
using System.Collections.Generic;
using UnityEngine;
public class Player : Entity
{
    BasePlayerData PlayerData = new BasePlayerData();
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
    public int CurrentHealth { get; set; }
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

    [SerializeField] public PlayerClass SelectedClass;

    StateMachine StateMachine;

    Dictionary<string, State> States;

    [SerializeField]
    public string CurrentStateString; // Just for debugging

    public State CurrentState;
    public Player()
    {
       CurrentHealth = MaxHealth;
       CurrentMana = MaxMana;
       PopulateStates();
       EventManager.PlayerClassSelection(SelectedClass);

    }

    public void OnEnable()
    {
        EventManager.OnPlayerStatChange += UpdateStats; // Call EventManager.PlayerStatChange() to update Stats
    }

    public void OnDisable()
    {
        EventManager.OnPlayerStatChange -= UpdateStats;
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
    
    public void ChangeState(State state) { StateMachine.ChangeState(state); }
    public void GetCurrentState() { CurrentState = StateMachine.CurrentState; CurrentStateString = StateMachine.CurrentState.name; } // Just for debugging
    public void PopulateStates()
    {
        States = new Dictionary<string, State>();
        //States.Add("Idle", new PlayerIdleState(gameObject));
        //States.Add("Move", new PlayerMoveState(gameObject));
        //States.Add("UseAbility", new PlayerAttackState(gameObject));
        //States.Add("Stun", new PlayerStunState(gameObject));
        //States.Add("Invulnerable", new PlayerInvulnerableState(gameObject));
        //States.Add("Death", new PlayerDeathState(gameObject));
    }
}