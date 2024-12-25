using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    // Current stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentMaxSpeed;

    void Awake()
    {
        currentMoveSpeed = enemyData.EnemyMoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentMaxSpeed = enemyData.MaxSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0) 
        {
            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage();
        }
    }
}
