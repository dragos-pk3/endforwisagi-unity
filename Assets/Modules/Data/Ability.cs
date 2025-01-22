using System.Collections;
using UnityEngine;


public abstract class Ability
{
    public string Name;
    public float Cooldown;
    public int ManaCost;
    public bool isOnCooldown = false;

    public Ability(string name, float cooldown, int manaCost)
    {
        Name = name;
        Cooldown = cooldown;
        ManaCost = manaCost;
    }
    public virtual void Cast(PlayerValues owner)
    {
        if (!isOnCooldown && (ManaCost <= owner.CurrentMana))
        {
            Debug.Log("Casting " + Name);
            owner.CurrentMana -= ManaCost;
            AbilityEffect(owner);
            owner.StartCoroutine(AbilityCooldown());
        }
        else
        {
            Debug.Log($"Ability *{Name}* is on cooldown or not enough mana");
        }
    }
    public abstract void AbilityEffect(PlayerValues owner);

    private IEnumerator AbilityCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(Cooldown);
        isOnCooldown = false;
    }



}