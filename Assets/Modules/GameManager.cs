using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();

                if (_instance == null)
                {
                    GameObject manager = new GameObject("GameManager");
                    _instance = manager.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // Subscribe to events
        EventManager.OnAppStart += LaunchApp;
    }

    private void OnDisable()
    {
        // Unsubscribe to events
        EventManager.OnAppStart -= LaunchApp;
    }

    private void LaunchApp()
    {
        Debug.Log("Started");
    }
}
