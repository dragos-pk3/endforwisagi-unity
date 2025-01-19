

using UnityEngine;
using System.Collections.Generic;

public class PlayerClassInitialization : MonoBehaviour
{

    //Class Data Structure for Modifiers and Abilities of each class
 
    public void OnEnable()
    {
        EventManager.OnPlayerClassSelection += InitializePlayerClass;
    }

    public void OnDisable()
    {
        EventManager.OnPlayerClassSelection -= InitializePlayerClass;
    }

    public void InitializePlayerClass(PlayerClass playerClass)
    {
        switch (playerClass)
        {
            case PlayerClass.Ninja:
                Debug.Log($"He is a {playerClass}");

                break;
            case PlayerClass.Magus:
                break;
            case PlayerClass.Knight:
                break;
            case PlayerClass.Warrior:
                break;
        }
    }

    private Dictionary<string, Ability> GetClassAbilities(Ability first, Ability second, Ability ultimate)
    {
        BaseSpells spells = new BaseSpells(first, second, ultimate);
        return spells.GetSpells;
    }
}