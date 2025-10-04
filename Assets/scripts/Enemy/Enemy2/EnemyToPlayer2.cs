using UnityEngine;

public class EnemyToPlayer2 : MonoBehaviour
{
    GameObject player;
    [SerializeField] private float teleportDistance = 5f;
    [SerializeField] private float TPcooldown = 0.5f;

    private float teleportTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleportTimer = 0f;
    }
    private void OnEnable()
    {
        GameManager.activeEnemies2.Add(this);
    }
    private void OnDisable()
    {
        GameManager.activeEnemies2.Remove(this);
    }
    public void UpdateEnemy()
    {
        Teleport();
    }
    private void Teleport()
    {
        teleportTimer += Time.deltaTime;
        if (teleportTimer >= TPcooldown)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            transform.position += direction * teleportDistance;
            teleportTimer = 0f;
        }
    }
}

