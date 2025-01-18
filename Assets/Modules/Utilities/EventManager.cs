using System;
using UnityEngine;

public static class EventManager
{
    #region Actions
    public static event Action OnPlayerStatChange;
    public static event Action<PlayerClass> OnPlayerClassSelection;
    public static event Action<int> OnPlayerDamaged;
    public static event Action OnWeaponHide;
    public static event Action OnWeaponShow;
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
    #endregion
}
