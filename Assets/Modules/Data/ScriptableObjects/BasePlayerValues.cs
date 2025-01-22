using UnityEngine;

[CreateAssetMenu(fileName = "BasePlayerValues", menuName = "Player/Base Values")]
public class BasePlayerValues : ScriptableObject 
{
    public int MaxHealth  = 100;
    public float DamageResistance  = 0.0f;
    public int Damage  = 10;
    public float Knockback  = 0.0f;
    public int MaxMana  = 100;
    public int ManaRegenRate  = 10;
    public float ManaRegenDelay  = 1.0f;
    public float MovementSpeed  = 5.0f;
    public float InvulnerabilityDuration  = 1.0f;
    public float RecoveryDuration  = 1.0f;

}
