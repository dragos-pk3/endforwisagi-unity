using System.Collections.Generic;
public class BaseSpells
{
    Dictionary<string, Ability> spells;

    public BaseSpells(Ability firstSpell, Ability secondSpell,Ability ultimateSpell)
    {
        spells = new Dictionary<string, Ability>();
        spells["First Spell"] = firstSpell;
        spells["Second Spell"] = secondSpell;
        spells["Ultimate Spell"] = ultimateSpell;
    }

    public Dictionary<string,Ability> GetSpells { get { return spells; } }
}
