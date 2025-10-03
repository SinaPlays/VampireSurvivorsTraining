using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float Health;

    void Start()
    {
        Health = maxHealth;
    }
    public void EnemyGetDamage(float SomeDamage)
    {
        if (gameObject.tag == "Player") { return; } // Prevents player from damaging enemy
        Health -= SomeDamage;
        if (Health <= 0)
        {
            EnemyDie();
        }
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
