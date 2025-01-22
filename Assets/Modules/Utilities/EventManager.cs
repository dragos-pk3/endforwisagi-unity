using System;
using UnityEngine;

public static class EventManager
{
    #region Actions
    public static event Action OnPlayerStatChange;
    public static event Action<PlayerClass> OnPlayerClassSelection;
    public static event Action<int> OnPlayerDamaged;
    public static event Action<int> OnPlayerDecreaseHealth;
    public static event Action OnWeaponHide;
    public static event Action OnWeaponShow;
    public static event Action OnCreateClones;
    public static event Action<int> OnEnemyDefeat;
    public static event Action OnPlayerDefeated;
    public static event Action<AbilityRank> OnPlayerCastingAbility;
    public static event Action OnNinjaBasicAbilityEnd;
    // Input 
    public static event Action OnPlayerMoveInput;
    public static event Action OnPlayerIdleInput;
    public static event Action OnPlayerAbilityInput;
    #endregion

    #region Game Manager Triggers

    #endregion

    #region Player Triggers
    public static void PlayerStatChange()
    {
        OnPlayerStatChange?.Invoke();
    }

    public static void PlayerClassSelection(PlayerClass playerClass)
    {
        OnPlayerClassSelection?.Invoke(playerClass);
    }

    public static void PlayerDamaged(int damage)
    {
        OnPlayerDamaged?.Invoke(damage);
    }
    public static void PlayerDecreaseHealth(int value)
    {
        OnPlayerDecreaseHealth?.Invoke(value);
    }

    public static void PlayerDefeatEnemy(int experience)
    {
        OnEnemyDefeat?.Invoke(experience);
    }

    public static void PlayerDefeated()
    {
        OnPlayerDefeated?.Invoke();
    }
    public static void PlayerIdle()
    {
        OnPlayerIdleInput?.Invoke();
    }
    public static void PlayerMoveInput()
    {
        OnPlayerMoveInput?.Invoke();
    }
    public static void PlayerCastingAbility(AbilityRank abilityRank)
    {
        OnPlayerCastingAbility?.Invoke(abilityRank);
    }
    #endregion

    #region Weapon
    public static void HideWeapon()
    {
        OnWeaponHide?.Invoke();
    }

    public static void ShowWeapon()
    {
        OnWeaponShow?.Invoke();
    }

    public static void DestroyWeaponClones()
    {
        OnNinjaBasicAbilityEnd?.Invoke();
    }
    public static void CreateClones()
    {
        OnCreateClones?.Invoke();
    }
    #endregion
}
