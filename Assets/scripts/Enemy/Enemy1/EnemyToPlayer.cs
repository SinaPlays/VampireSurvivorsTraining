using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    GameObject player;
    Vector3 playerPosition;
    [SerializeField] private float MovementSpeed;
    private Vector3 Direction;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
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
