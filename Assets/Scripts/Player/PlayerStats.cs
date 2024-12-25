using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    // current stats
    public int currentHealth;
    public float currentHealthRegeneration;
    public float currentMoveSpeed;
    public float currentMaxSpeed;
    public float currentMagnetRange;

    // Experience and Levels
    [Header("Experience/Levels")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    [Header("Invincibility Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    public List<LevelRange> levelRanges;

    private void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentHealthRegeneration = characterData.HealthRegeneration;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMaxSpeed = characterData.MaxSpeed;
        currentMagnetRange = characterData.MagnetRange;
    }

    void Start()
    {
        // Initial experience cap is the first experience cap increase to prevent the cap starting at zero and levelling up immediately
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    private void Update()
    {
        if (isInvincible) 
        {
            invincibilityTimer -= Time.deltaTime;
            if(invincibilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
    }

    void LevelUpChecker()
    {
        if(experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            
            foreach(LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCap += range.experienceCapIncrease;
                    break;
                }
            }
        }
    }

    public void TakeDamage()
    {
        if (isInvincible)
            return;

        currentHealth--;

        invincibilityTimer = invincibilityDuration;
        isInvincible = true;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Debug.Log("Player is kill :c");
    }

    public void RestoreHealth(int amount)
    {
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;

            // make sure health does not go over maximum
            if(currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }
}
