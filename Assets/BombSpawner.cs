using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    private PlayerValues playerValues;
    [SerializeField] private Bomb bomb;

    private void OnEnable()
    {
        EventManager.OnSpawnBomb += SpawnBomb;
    }

    private void OnDisable()
    {
        EventManager.OnSpawnBomb -= SpawnBomb;
    }

    private void Awake()
    {

    }

    void SpawnBomb(PlayerValues owner)
    {
        Instantiate(bomb, owner.transform.position, Quaternion.identity);
    }
}
