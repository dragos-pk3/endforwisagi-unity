using UnityEngine;

public class DemoObserver : MonoBehaviour, IObserver
{
    private PlayerStatsHandler _stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _stats = FindFirstObjectByType<PlayerStatsHandler>(); // only for prototyping  
    }
    public void OnNotify(ISubject subject)
    {
        Debug.Log($"I am notified by subject. Reading movement stat:{_stats.MovementSpeed}");
    }
}
