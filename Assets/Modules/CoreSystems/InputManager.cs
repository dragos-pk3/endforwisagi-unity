using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Move player
            Debug.Log("Player is moving");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // First ability
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // Second Ability
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Ultimate
        }


    }
}
