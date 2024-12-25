using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    // Base stats for enemies
    [SerializeField]
    float enemyMoveSpeed;
    public float EnemyMoveSpeed { get => enemyMoveSpeed; set => enemyMoveSpeed = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    float maxSpeed;
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
}
