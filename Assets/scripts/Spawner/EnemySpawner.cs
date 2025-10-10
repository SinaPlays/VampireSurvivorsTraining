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

    void Update()
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
        if (gameTimer < 20)
        {
            Instantiate(enemyPrefab1, transform.position, Quaternion.identity);
        }
        else
        {
            int randomEnemy = Random.Range(0, 2);
            if (randomEnemy == 0)
            {
                Instantiate(enemyPrefab1, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab2, transform.position, Quaternion.identity);
            }
        }
        spawnTimer = 0;
    }

    public void IncreaseDifficulty()
    {
        spawnInterval *= 0.95f;
        healthMultiplier *= 1.05f;
    }
}