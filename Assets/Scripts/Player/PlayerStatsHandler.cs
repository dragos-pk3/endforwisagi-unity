using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    [Header("Reference to Base Stats ScriptableObject")]
    public PlayerStats basePlayerStats;

    [Header("Chosen Class for this Player")]
    public PlayerClass playerClass;

    // Final stats in this instance
    private int currentEndurance;
    private int currentForce;
    private int currentWisdom;
    private int currentAgility;

    void Start()
    {
        // Copy base stats
        currentEndurance = basePlayerStats.endurance;
        currentForce = basePlayerStats.force;
        currentWisdom = basePlayerStats.wisdom;
        currentAgility = basePlayerStats.agility;

        // Apply class-specific modifications
        ApplyClassModifiers();

        // Now currentEndurance, currentForce, currentWisdom, currentAgility
        // contain the final stats for this particular character.
        Debug.Log($"Player is a {playerClass.className} with stats:\n" +
                  $"Endurance = {currentEndurance}, Force = {currentForce},\n" +
                  $"Wisdom = {currentWisdom}, Agility = {currentAgility}.");
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
