using System.Collections.Generic;
public struct StatProperty<T>
{
    public T BaseValue { get; set; }
    public float Multiplier { get; set; }

    public StatProperty(T baseValue, float multiplier)
    {
        BaseValue = baseValue;
        Multiplier = multiplier;
    }
}
public class BasePlayerData
{
    public Dictionary<StatType, int> stats = new Dictionary<StatType, int>();
    
    // Endurance
    public StatProperty<int> BaseHealth;
    public StatProperty<int> BaseHealthRechargeRate;
    public StatProperty<float> BaseHealthRegenDelay;

    // Force
    public StatProperty<int> BaseAttack;
    public StatProperty<float> BaseKnockback;

    // Wisdom
    public StatProperty<int> BaseMana;
    public StatProperty<int> BaseManaRechargeRate;
    public StatProperty<float> BaseManaRechargeDelay;

    // Agility
    public StatProperty<float> BaseMovementSpeed;

    public BasePlayerData()
    {
        // Stats
        stats.Add(StatType.Endurance, 10);
        stats.Add(StatType.Force, 10);
        stats.Add(StatType.Wisdom, 10);
        stats.Add(StatType.Agility, 10);
        
        // Propereties
        BaseMovementSpeed = new StatProperty<float>(10f, 1f);
    }


}
