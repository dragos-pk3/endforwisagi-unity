using System;
using UnityEngine;

public static class EventManager
{
    public static event Action OnAppStart;



    public static void AppStart()
    {
        OnAppStart?.Invoke();
    }
}
