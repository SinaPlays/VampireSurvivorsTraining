using UnityEngine;

public class EnemyToPlayer2 : MonoBehaviour
{
    GameObject player;

    [SerializeField] private float teleportDistance = 5f;
    [SerializeField] private float TPcooldown = 0.5f;

    private float teleportTimer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        teleportTimer = 0f;
    }
    private void Update()
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

