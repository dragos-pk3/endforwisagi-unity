using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour
{
    [Header("Reference to Base Stats ScriptableObject")]
    public PlayerStats basePlayerStats;

    [Header("Chosen Class for this Player")]
    public PlayerClass playerClass;

    private int currentEndurance;
    private int currentForce;
    private int currentWisdom;
    private int currentAgility;


    // Endurance
    private int _maxHealth;
    private int _currentHealth;
    private int _healthRechargeRate;

    // Force
    private int _attack;
    private float _knockback;

    // Wisdom
    private int _maxMana;
    private int _currentMana;
    private int _manaRechargeRate;

    // Agility
    private float _movementSpeed;
    private float _iFramesDuration;
    private float _recoveryDelay;
    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = Mathf.Max(0, value); // Ensures health is not set below 0
    }

    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth); // Clamps current health between 0 and max health
    }

    public int HealthRechargeRate
    {
        get => _healthRechargeRate;
        set => _healthRechargeRate = Mathf.Max(0, value); // Ensures recharge rate is not negative
    }

    public int Attack
    {
        get => _attack;
        set => _attack = Mathf.Max(0, value); // Attack should not be negative
    }

    public float Knockback
    {
        get => _knockback;
        set => _knockback = Mathf.Max(0, value); // Knockback should not be negative
    }

    public int MaxMana
    {
        get => _maxMana;
        set => _maxMana = Mathf.Max(0, value); // Ensures max mana is not negative
    }

    public int CurrentMana
    {
        get => _currentMana;
        set => _currentMana = Mathf.Clamp(value, 0, _maxMana); // Clamps current mana between 0 and max mana
    }

    public int ManaRechargeRate
    {
        get => _manaRechargeRate;
        set => _manaRechargeRate = Mathf.Max(0, value); // Ensures recharge rate is not negative
    }

    public float MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = Mathf.Max(0, value); // Ensures movement speed is not negative
    }

    public float IFramesDuration
    {
        get => _iFramesDuration;
        set => _iFramesDuration = Mathf.Max(0, value); // Ensures iFrames duration is not negative
    }

    public float RecoveryDelay
    {
        get => _recoveryDelay;
        set => _recoveryDelay = Mathf.Max(0, value); // Ensures recovery delay is not negative
    }

    void Start()
    {
        currentEndurance = basePlayerStats.endurance;
        currentForce = basePlayerStats.force;
        currentWisdom = basePlayerStats.wisdom;
        currentAgility = basePlayerStats.agility;

        ApplyClassModifiers();

        _movementSpeed = 5f;//debug line
    }

    private void ApplyClassModifiers()
    {
        foreach (var modifier in playerClass.statModifiers)
        {
            switch (modifier.statType)
            {
                case StatType.Endurance:
                    currentEndurance += modifier.value;
                    break;
                case StatType.Force:
                    currentForce += modifier.value;
                    break;
                case StatType.Wisdom:
                    currentWisdom += modifier.value;
                    break;
                case StatType.Agility:
                    currentAgility += modifier.value;
                    break;
            }
        }
    }
}
