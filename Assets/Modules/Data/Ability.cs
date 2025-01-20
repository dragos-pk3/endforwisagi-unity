using UnityEngine;

[System.Serializable]
public abstract class Ability
{
    public string Name;
    public float Cooldown;
    public int ManaCost;

    public Ability(string name, float cooldown, int manaCost)
    {
        Name = name;
        Cooldown = cooldown;
        ManaCost = manaCost;
    }
    public abstract void Cast(Player owner);

}