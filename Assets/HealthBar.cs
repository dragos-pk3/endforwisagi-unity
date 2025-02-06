using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
    }


    void UpdatePlayerHealth(float amount)
    {
        slider.value = amount;
    }

    private void OnEnable()
    {
        EventManager.OnPlayerHealthChange += UpdatePlayerHealth;
    }
    private void OnDisable()
    {
        EventManager.OnPlayerHealthChange -= UpdatePlayerHealth;
    }
}

