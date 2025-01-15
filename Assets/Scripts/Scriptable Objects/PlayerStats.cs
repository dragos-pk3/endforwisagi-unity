using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Stats", fileName = "BasePlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Base Stats for Level 1 Character")]
    public int endurance = 9;
    public int force = 9;
    public int wisdom = 9;
    public int agility = 9;
}