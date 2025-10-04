using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab1;
    GameObject enemyPrefab2;
    [SerializeField] private float spawnInterval = 2f;

    private float spawnTimer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        SpawnTimer();
    }

    void SpawnTimer()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab1, transform.position, Quaternion.identity);
        spawnTimer = 0;
    }
}
