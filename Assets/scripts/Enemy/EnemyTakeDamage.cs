using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float Health;

    PlayerExperience playerExperience;
    void Start()
    {
        Health = maxHealth;
        playerExperience = FindFirstObjectByType<PlayerExperience>();
    }
    public void EnemyGetDamage(float SomeDamage)
    {
        if (gameObject.tag == "Player") { return; } 
        Health -= SomeDamage;
        if (Health <= 0)
        {
            EnemyDie();
        }
    }
    public void EnemyDie()
    {
        playerExperience.GainXP(1);
        GameManager.instance.EnemyKilled();
        Destroy(gameObject);
    }
}
