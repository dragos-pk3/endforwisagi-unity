using System;
using UnityEngine;

public class NinjaWeaponBehaviour : MonoBehaviour
{

    public Transform player;

    private Transform sprite;
    private BoxCollider2D boxCollider;
        
    [Header("Offset & Orbit Settings")]
    [Tooltip("Initial offset from the player's position.")]
    public float distanceFromPlayer = 1f;
    [Tooltip("How fast the weapon orbits around the player (degrees per second).")]
    public float orbitSpeed = 90f;

    private float orbitAngle = 0f;

    private void Start()
    {
        sprite = transform.Find("Pivot"); // TODO: This is ugly
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (player == null) return;
        orbitAngle += orbitSpeed * Time.deltaTime;

        if (orbitAngle > 360f) orbitAngle -= 360f;
        if (orbitAngle < 0f) orbitAngle += 360f;

        float radians = orbitAngle * Mathf.Deg2Rad;

        float x = player.position.x + distanceFromPlayer * Mathf.Cos(radians);
        float y = player.position.y + distanceFromPlayer * Mathf.Sin(radians);

        transform.position = new Vector3(x,y, transform.position.z);
    }

    private void OnEnable()
    {
        EventManager.OnWeaponHide += HideWeapon;
        EventManager.OnWeaponShow += ShowWeapon;
    }
    private void OnDisable()
    {
        EventManager.OnWeaponHide -= HideWeapon;
        EventManager.OnWeaponShow -= ShowWeapon;

    }
    private void ShowWeapon()
    {
        boxCollider.enabled = true;
        foreach (Transform child in sprite) {
            child.gameObject.SetActive(true);
        }
    }

    private void HideWeapon()
    {
        boxCollider.enabled = false;
        foreach (Transform child in sprite) {
            child.gameObject.SetActive(false);
        }
    }

}
