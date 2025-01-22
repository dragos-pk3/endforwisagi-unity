using UnityEngine;

public class FiveStarNinja : Ability
{
    public FiveStarNinja(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) { }

    public override void AbilityEffect(PlayerValues owner)
    {
        // create 5 clones of the weapon
    }
}