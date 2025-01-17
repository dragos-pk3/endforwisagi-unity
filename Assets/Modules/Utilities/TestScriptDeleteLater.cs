using UnityEngine;

public class TestScriptDeleteLater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Triggering the event");
        EventManager.AppStart();
    }


}
