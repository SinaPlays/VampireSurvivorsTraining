using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] private float spawnInterval = 2f;

    private float spawnTimer = 0f;
    private float gameTimer = 0f;
    private int timeMultiplier = 0;
    public static float healthMultiplier = 1f;

    [SerializeField] private Transform player;
    public void UpdateSpawner()
    {
        gameTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (gameTimer > (timeMultiplier + 1) * 10)
        {
            timeMultiplier++;
            IncreaseDifficulty();
        }

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        if (gameTimer < 20)
        {
            Instantiate(enemyPrefab1, spawnPosition, Quaternion.identity);
        }
        else
        {
            int randomEnemy = Random.Range(0, 2);
            if (randomEnemy == 0)
            {
                Instantiate(enemyPrefab1, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity);
            }
        }
        spawnTimer = 0;
    }

    public void IncreaseDifficulty()
    {
        spawnInterval *= 0.95f;
        healthMultiplier *= 1.05f;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = 0;
        float y = 0;

        int side = Random.Range(0, 4);

        if (side == 0) // Top
        {
            x = Random.Range(player.position.x - 11f, player.position.x + 11f);
            y = player.position.y + 6f;
        }
        else if (side == 1) // Bottom
        {
            x = Random.Range(player.position.x - 11f, player.position.x + 11f);
            y = player.position.y - 6f;
        }
        else if (side == 2) // Right
        {
            x = player.position.x + 12f;
            y = Random.Range(player.position.y - 6f, player.position.y + 6f);
        }
        else // Left
        {
            x = player.position.x - 12f;
            y = Random.Range(player.position.y - 6f, player.position.y + 6f);
        }

        return new Vector3(x, y, 0);
    }
}