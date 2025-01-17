[System.Serializable]
public class Ability
{
    public string Name;
    public float Cooldown;
    public float ManaCost;

    public Ability(string name, float cooldown, float manaCost)
    {
        Name = name;
        Cooldown = cooldown;
        ManaCost = manaCost;
    }
}