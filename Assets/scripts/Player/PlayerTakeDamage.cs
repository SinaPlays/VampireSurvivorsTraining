using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float Health;
    float damage;
    [SerializeField] float DamageMultiplier;

    [Header("UI")]
    [SerializeField] Image HealthBar;
    [SerializeField] TextMeshProUGUI HealthText;


    private void Start()
    {
        Health = maxHealth;
    }
    private void Update()
    {
        HealthText.text = Health.ToString() + " / " + maxHealth.ToString();
        HealthBar.fillAmount = Health / maxHealth;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        damage = DamageMultiplier * Time.deltaTime;
        if (collision.CompareTag("Enemy"))
            PlayerGetDamage(damage);
    }
    void PlayerGetDamage(float SomeDamage)
    {
        if (GameManager.instance.currentState != GameManager.GameState.Playing)
        {
            return;
        }
        Health -= SomeDamage;
        if (Health <= 0)
        {
            PlayerDie();
        }
    }
    void PlayerDie()
    {
        GameManager.instance.ChangeState(GameManager.GameState.GameOver);
        gameObject.SetActive(false);
    }
}