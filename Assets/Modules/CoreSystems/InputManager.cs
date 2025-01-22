using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private void Awake()
    {
        
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            EventManager.PlayerMoveInput();
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            EventManager.PlayerIdle();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.PlayerCastingAbility(AbilityRank.Basic);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            EventManager.PlayerCastingAbility(AbilityRank.Secondary);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            EventManager.PlayerCastingAbility(AbilityRank.Ultimate);
        }


    }
}
