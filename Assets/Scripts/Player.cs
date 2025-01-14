using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic
public class Player : MonoBehaviour, ISubject
{

    private List<IObserver> _observers = new List<IObserver>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attach(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            {
                _observers.Add(observer); // Player attached an observer  
            }
        }

    }
    public void Detach(IObserver observer)
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
