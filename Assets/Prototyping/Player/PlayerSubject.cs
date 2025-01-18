using System.Collections.Generic;
using UnityEngine;
public class PlayerSubject : MonoBehaviour, ISubject
{

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
