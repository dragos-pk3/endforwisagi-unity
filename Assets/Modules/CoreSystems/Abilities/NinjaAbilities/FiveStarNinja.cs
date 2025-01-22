using System.Collections;
using UnityEngine;

public class FiveStarNinja : Ability
{
    public FiveStarNinja(string name, float cooldown, int manaCost) : base(name, cooldown, manaCost) { }
    bool abilityActive = false;
    float abilityDuration = 3;
    public override void AbilityEffect(PlayerValues owner)
    {
        EventManager.CreateClones();
        owner.StartCoroutine(AbilityDuration());
    }

    private IEnumerator AbilityDuration()
    {
        abilityActive = true;
        yield return new WaitForSeconds(abilityDuration);
        EventManager.DestroyWeaponClones();
        abilityActive = false;
    }
}