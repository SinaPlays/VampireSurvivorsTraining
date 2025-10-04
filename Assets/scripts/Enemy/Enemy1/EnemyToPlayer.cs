using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    GameObject player;
    Vector3 playerPosition;
    [SerializeField] private float MovementSpeed;
    private Vector3 Direction;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    { 
        GameManager.activeEnemies.Add(this);
    }
    private void OnDisable()
    {
        GameManager.activeEnemies.Remove(this);
    }
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
