using System;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    private SpriteRenderer[] WhipSprites;
    private EdgeCollider2D WhipCollider;

    GameObject player;
    Vector3 WhipPosition;
    [SerializeField] float WhipTimer;

    [SerializeField] float WhipDuration = 0.3f;
    [SerializeField] float WhipCooldown = 1;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WhipSprites = GetComponentsInChildren<SpriteRenderer>();
        WhipCollider = GetComponent<EdgeCollider2D>();
    }
    private void Update()
    {
        WhipPositionSet();
        WhipLogic();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyTakeDamage>().EnemyGetDamage(2);
        }
    }
    private void WhipPositionSet()
    {
        WhipPosition = player.transform.position + new Vector3(0.81f, -0.12f, 0f);
        transform.position = WhipPosition;
    }
    private void WhipLogic()
    {
        WhipTimer += Time.deltaTime;

        if (WhipTimer >= WhipCooldown)
        {
            WhipTimer = 0;

            foreach (var sprite in WhipSprites)
            {
                sprite.enabled = true;
            }
            WhipCollider.enabled = true;
        }

        if (WhipTimer >= WhipDuration)
        {
            foreach (var sprite in WhipSprites)
            {
                sprite.enabled = false;
            }
            WhipCollider.enabled = false;
        }
    }
}
