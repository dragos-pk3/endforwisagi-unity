

using UnityEngine;

public class PlayerClassInitialization : MonoBehaviour
{

    //Class Data Structure for Modifiers and Abilities of each class
    
    public void OnEnable()
    {
        EventManager.OnPlayerClassSelection += InitializePlayerClass;
    }

    public void OnDisable()
    {
        EventManager.OnPlayerClassSelection -= InitializePlayerClass;
    }

    public void InitializePlayerClass(PlayerClass playerClass)
    {
        switch (playerClass)
        {
            case PlayerClass.Ninja:
                break;
            case PlayerClass.Magus:
                break;
            case PlayerClass.Knight:
                break;
            case PlayerClass.Warrior:
                break;
        }
    }


}