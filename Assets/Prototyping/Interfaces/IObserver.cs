using UnityEngine;

public interface IObserver
{
    void OnNotify(ISubject subject);
}
