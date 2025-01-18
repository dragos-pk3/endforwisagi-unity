using System;
using UnityEngine;

public static class EventManager
{
    #region Actions
    public static event Action OnPlayerStatChange;
    public static event Action<PlayerClass> OnPlayerClassSelection;
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
    #endregion
}
