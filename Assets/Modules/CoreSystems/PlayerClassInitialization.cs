

using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerClassInitialization : MonoBehaviour
{
    BaseSpells baseSpells;

    //Class Data Structure for Modifiers and Abilities of each class
    private void Start()
    {
        baseSpells = GetComponent<BaseSpells>();   
    }
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

                NinjaDiscipline ninja_q = new NinjaDiscipline("Ninja Discipline", 3f, 30);
                baseSpells.firstSpell = ninja_q;
                baseSpells.secondSpell = ninja_q;
                baseSpells.thirdSpell = ninja_q;
                Debug.Log($"ninja has {baseSpells.firstSpell.Name}");

                break;
            case PlayerClass.Magus:
                break;
            case PlayerClass.Knight:
                break;
            case PlayerClass.Warrior:
                break;
        }
    }
}