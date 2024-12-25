using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    // Base Character Stats
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; set => startingWeapon = value;}

    [SerializeField]
    int maxHealth;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    float healthRegeneration;
    public float HealthRegeneration { get => healthRegeneration; set => healthRegeneration = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    float maxSpeed;
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

    [SerializeField]
    float magnetRange;
    public float MagnetRange { get => magnetRange; set => magnetRange = value; }
}
