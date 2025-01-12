using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn Settings")]
    public GameObject enemyPrefab;     
    public float spawnOffset = 2f;    
    public float spawnInterval = 0.2f;  
    public float enemiesPerWave = 3;
    
    private Camera mainCamera;
    private int enemiesSpawned = 0;

    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval); 
    }

    private void SpawnEnemy()
    {
        if (enemiesSpawned >= enemiesPerWave)
        {
            CancelInvoke(nameof(SpawnEnemy));
            return;
        }
        Vector2 spawnPosition = GetRandomOffScreenPosition();

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemiesSpawned++;
    }

    private Vector2 GetRandomOffScreenPosition()
    {
        float screenWidth = mainCamera.orthographicSize * Screen.width / Screen.height;
        float screenHeight = mainCamera.orthographicSize;

        int randomSide = Random.Range(0, 4);

        Vector2 spawnPosition = Vector2.zero;

        switch (randomSide)
        {
            case 0: // Top
                spawnPosition = new Vector2(
                    Random.Range(-screenWidth, screenWidth),
                    screenHeight + spawnOffset
                );
                break;

            case 1: // Bottom
                spawnPosition = new Vector2(
                    Random.Range(-screenWidth, screenWidth),
                    -screenHeight - spawnOffset
                );
                break;

            case 2: // Left
                spawnPosition = new Vector2(
                    -screenWidth - spawnOffset,
                    Random.Range(-screenHeight, screenHeight)
                );
                break;

            case 3: // Right
                spawnPosition = new Vector2(
                    screenWidth + spawnOffset,
                    Random.Range(-screenHeight, screenHeight)
                );
                break;
        }

        return spawnPosition;
    }
}
