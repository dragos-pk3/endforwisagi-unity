using System.Collections;
using UnityEngine;

public class NinjaDiscipline : Ability
{
    public NinjaDiscipline(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) { }

    public override void AbilityEffect(PlayerValues owner)
    {
        owner.playerStats.Agility.value += 10;
        EventManager.UpdatePlayerValues();
        owner.StartCoroutine(RevertStats(owner));
    }

    private IEnumerator RevertStats(PlayerValues owner)
    {
        yield return new WaitForSeconds(5);
        owner.playerStats.Agility.value -= 10;
        EventManager.UpdatePlayerValues();

    }
}