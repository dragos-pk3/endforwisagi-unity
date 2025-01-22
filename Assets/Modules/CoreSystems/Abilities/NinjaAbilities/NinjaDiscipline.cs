using UnityEngine;

public class NinjaDiscipline : Ability
{
    public NinjaDiscipline(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) { }

    public override void AbilityEffect(PlayerValues owner)
    {
        // raise player agility and update the stats then revert back to normal
    }
}