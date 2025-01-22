

using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerClassInitialization : MonoBehaviour
{
    public Dictionary<AbilityRank, Ability> abilities = new Dictionary<AbilityRank, Ability>();
    PlayerValues playerValues;
    private void Awake()
    {
        playerValues = GetComponent<PlayerValues>();
    }
    public void OnEnable()
    {
        EventManager.OnPlayerClassSelection += InitializePlayerClass;
        EventManager.OnPlayerCastingAbility += CastAbility;
    }
    public void OnDisable()
    {
        EventManager.OnPlayerClassSelection -= InitializePlayerClass;
        EventManager.OnPlayerCastingAbility += CastAbility;

    }

    public void InitializePlayerClass(PlayerClass playerClass)
    {
        switch (playerClass)
        {
            case PlayerClass.Ninja:

                abilities.Add(AbilityRank.Basic, new FiveStarNinja("Five Star Ninja",10,25));
                abilities.Add(AbilityRank.Secondary, new NinjaDash("Dash", 3, 15));
                abilities.Add(AbilityRank.Ultimate, new NinjaDiscipline("Ninja Discipline", 12, 50));
                break;
            case PlayerClass.Magus:
                break;
            case PlayerClass.Knight:
                break;
            case PlayerClass.Warrior:
                break;
        }
    }

    public void CastAbility(AbilityRank abilityRank)
    {
        if (abilities.ContainsKey(abilityRank))
        {
            abilities[abilityRank].Cast(playerValues);
        }
    }

}