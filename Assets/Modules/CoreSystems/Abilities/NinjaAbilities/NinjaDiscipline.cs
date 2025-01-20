using UnityEngine;

public class NinjaDiscipline : Ability
{
    public NinjaDiscipline(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) {
    }
    public override void Cast(Player owner)
    {
        Debug.Log($"CASTING {Name}");

    }
}