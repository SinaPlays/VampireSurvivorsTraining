using UnityEditor.Analytics;
using UnityEngine;


public class GarlicWeapon : MonoBehaviour
{
    GameObject player;
    public float garlicStrength = 1;
    float Damage;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void UpdateGarlic()
    {
        transform.position = player.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Damage = garlicStrength * Time.deltaTime;
            collision.GetComponent<EnemyTakeDamage>().EnemyGetDamage(Damage);
        }
    }
}
