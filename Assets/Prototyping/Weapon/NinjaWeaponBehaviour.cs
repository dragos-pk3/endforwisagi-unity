using UnityEngine;

public class NinjaWeaponBehaviour : MonoBehaviour
{

    public Transform player;

    [Header("Offset & Orbit Settings")]
    [Tooltip("Initial offset from the player's position.")]
    public float distanceFromPlayer = 1f;
    [Tooltip("How fast the weapon orbits around the player (degrees per second).")]
    public float orbitSpeed = 90f;

    private float orbitAngle = 0f;

    private void Start()
    {
    }

    private void Update()
    {
        orbitAngle += orbitSpeed * Time.deltaTime;

        if (orbitAngle > 360f) orbitAngle -= 360f;
        if (orbitAngle < 0f) orbitAngle += 360f;

        float radians = orbitAngle * Mathf.Deg2Rad;

        float x = player.position.x + distanceFromPlayer * Mathf.Cos(radians);
        float y = player.position.y + distanceFromPlayer * Mathf.Sin(radians);

        transform.position = new Vector3(x,y, transform.position.z);
    }
}
