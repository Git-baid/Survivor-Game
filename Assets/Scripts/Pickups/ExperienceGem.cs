using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour, ICollectible
{
    PlayerCollector collector;
    public int experienceGranted;

    void Start()
    {
        collector = FindObjectOfType<PlayerCollector>();
    }
    public void Collect()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats player = FindObjectOfType<PlayerStats>();
            player.IncreaseExperience(experienceGranted);
            Destroy(gameObject);
        }
            
    }

    private void OnDestroy()
    {
        collector.collectedItems.Remove(gameObject.GetComponent<Rigidbody2D>());
    }

}
