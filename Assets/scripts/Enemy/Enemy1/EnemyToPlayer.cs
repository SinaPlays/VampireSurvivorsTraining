using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 playerPosition;
    [SerializeField] private float MovementSpeed;
    private Vector3 Direction;

    public void UpdateEnemy()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        if (player != null)
        {
            playerPosition = player.transform.position; 
            Direction = (playerPosition - transform.position).normalized;
            transform.position += Direction * MovementSpeed * Time.deltaTime;
        }
    }
}
