using UnityEngine;

public class EnemyToPlayer2 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private float teleportDistance = 5f;
    [SerializeField] private float TPcooldown = 0.5f;

    private float teleportTimer;

    private void Start()
    {
        teleportTimer = 0f;
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

