using System.Collections;
using UnityEngine;


public class PlayerValues : MonoBehaviour
{
    [SerializeField] public BasePlayerValues baseValues;
    PlayerStats playerStats = new PlayerStats();
    PlayerProgression playerProgression = new PlayerProgression(20);

    // ENDURANCE
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int MaxHealth ;
    [SerializeField] public float DamageResistance ;

    // FORCE
    [SerializeField] public int Damage ;
    [SerializeField] public float Knockback ;

    // WISDOM
    [SerializeField] public int MaxMana ;
    [SerializeField] public int CurrentMana ;

    [SerializeField] public int ManaRegenRate ;
    [SerializeField] public float ManaRegenDelay ;

    // AGILITY
    [SerializeField] public float MovementSpeed ;
    [SerializeField] public float InvulnerabilityDuration ;
    [SerializeField] public float RecoveryDuration ;

    // Class specific values

    private bool isRegeneratingMana = false;
    private void Awake()
    {
        UpdateAllValues();
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        Debug.Log("Movement Speed value:" + MovementSpeed);
    }
    private void UpdateAllValues()
    {
        SetPlayerMaxHealth();
        SetPlayerResistance();
        SetPlayerMaxMana();
        SetPlayerManaRegenRate();
        SetPlayerManaRegenDelay();
        SetPlayerDamage();
        SetPlayerKnockback();
        SetPlayerMovementSpeed();
        SetPlayerInvulnerabilityDuration();
        SetPlayerRecoveryDuration();
    }
    public int SetValue(int baseValue, int stat, float multiplier, GrowthType growthType = GrowthType.Linear)
    {
        switch (growthType)
        {
            case GrowthType.Linear:
                return baseValue + (int)(stat * multiplier);
            case GrowthType.Exponential:
                return baseValue + (int)(Mathf.Pow(stat, multiplier));
            case GrowthType.Logarithmic:
                return baseValue + (int)(Mathf.Log(stat + 1) * multiplier);
        }
        return baseValue + (int)(stat * multiplier);
    }
    public float SetValue(float baseValue, int stat, float multiplier, GrowthType growthType = GrowthType.Linear)
    {
        switch (growthType)
        {
            case GrowthType.Linear:
                return baseValue + (stat * multiplier);
            case GrowthType.Exponential:
                return baseValue + Mathf.Pow(stat, multiplier);
            case GrowthType.Logarithmic:
                return baseValue + Mathf.Log(stat + 1) * multiplier; // +1 to avoid log(0)
            default:
                return baseValue;
        }
    }

    private void SetPlayerMaxHealth()
    {
        MaxHealth = SetValue(baseValues.MaxHealth, playerStats.Endurance.value, 1);
    }

    private void SetPlayerMaxMana()
    {
        MaxMana = SetValue(baseValues.MaxMana, playerStats.Wisdom.value, 1);
    }

    private void SetPlayerManaRegenRate()
    {
        ManaRegenRate = SetValue(baseValues.ManaRegenRate, playerStats.Wisdom.value, 1);
    }
    private void SetPlayerManaRegenDelay()
    {
        ManaRegenDelay = SetValue(baseValues.ManaRegenDelay, playerStats.Wisdom.value, 0);
    }
    private void SetPlayerResistance()
    {
        DamageResistance = SetValue(baseValues.DamageResistance, playerStats.Endurance.value, 1);
    }
    private void SetPlayerDamage()
    {
        Damage = SetValue(baseValues.Damage, playerStats.Force.value, 1);
    }

    private void SetPlayerKnockback()
    {
        Knockback = SetValue(baseValues.Knockback, playerStats.Force.value, 1);
    }

    private void SetPlayerMovementSpeed()
    {
        MovementSpeed = SetValue(baseValues.MovementSpeed, playerStats.Agility.value, 0.2f);
    }

    private void SetPlayerInvulnerabilityDuration()
    {
        InvulnerabilityDuration = SetValue(baseValues.InvulnerabilityDuration, playerStats.Agility.value, 1);
    }

    private void SetPlayerRecoveryDuration()
    {
        RecoveryDuration = SetValue(baseValues.RecoveryDuration, playerStats.Agility.value, 0.1f);
    }

    public void UseMana(int mana)
    {

        if (CurrentMana >= mana)
        {
            CurrentMana = Mathf.Clamp(CurrentMana - mana, 0, MaxMana);
            if (isRegeneratingMana)
            {
                StopCoroutine(RegenerateManaCoroutine());
                isRegeneratingMana = false;
            }
            StartCoroutine(RegenerateManaCoroutine());
        }
        else Debug.Log("Not enough mana");
    }

    private IEnumerator RegenerateManaCoroutine()
    {
        isRegeneratingMana = true;
        yield return new WaitForSeconds(ManaRegenDelay);
        while (CurrentMana < MaxMana)
        {
            RegenMana();
            yield return new WaitForSeconds(1);
        }
        isRegeneratingMana = false;
    }
    public void AdjustHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
        if (CurrentHealth == 0) EventManager.PlayerDefeated();
    }

    public void RegenMana()
    {
        CurrentMana = Mathf.Clamp(CurrentMana + ManaRegenRate, 0, MaxMana);
    }
    private void GainExp(int value)
    {
        playerProgression.experience += value;
        playerProgression.LevelUp();
        playerProgression.PrintAllValues();
    }

    public void OnEnable()
    {
        EventManager.OnEnemyDefeat += GainExp;
        EventManager.OnPlayerDecreaseHealth += AdjustHealth;
    }

    public void OnDisable()
    {
        EventManager.OnEnemyDefeat -= GainExp;
        EventManager.OnPlayerDecreaseHealth -= AdjustHealth;
    }
}
