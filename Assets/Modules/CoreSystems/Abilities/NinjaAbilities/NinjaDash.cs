using UnityEngine;

public class NinjaDash : Ability
{
    public NinjaDash(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) { }

    public override void AbilityEffect(PlayerValues owner)
    {
        // dash toward the direction the player is facing leaving a bomb that explodes on enemies after a brief delay, don't allow the player to dash off screen
    }
}