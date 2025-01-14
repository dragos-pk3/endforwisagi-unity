using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class Player : MonoBehaviour, ISubject
{
    // REMINDER: 
    // Subscribe families of/tagged components when certain commands/action take place 
    // (for example StatIncrease action will subscribe StatUiElements, update them with notification then unsubscribe them!!!!)
    // Notify the Subscribers
    // Unsubscribe them
    // ???
    // profit
    private List<IObserver> _observers = new List<IObserver>();
    public void Subscribe(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            {
                _observers.Add(observer); // Player attached an observer  
            }
        }

    }
    public void Unsubscribe(IObserver observer)
    {
        if(_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(this);
        }
    }

}
