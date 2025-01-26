using UnityEngine;

public class NinjaDash : Ability
{
    public NinjaDash(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) { }
    private float distance = 20f;
    public override void AbilityEffect(PlayerValues owner)
    {
        EventManager.SpawnBomb(owner);
        EventManager.PlayerDash();
    }
}
