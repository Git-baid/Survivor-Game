using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;
    [SerializeField]
    float magnetAnimationStrength;

    public List<Rigidbody2D> collectedItems;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
        collectedItems = new List<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerCollector.radius = player.currentMagnetRange;
        foreach (Rigidbody2D rb in collectedItems)
        {
            Vector2 forceDirection = (transform.position - rb.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed * Time.fixedDeltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision object has ICollectible script
        if (collision.gameObject.TryGetComponent(out ICollectible collectible) && !collectedItems.Contains(collision.gameObject.GetComponent<Rigidbody2D>()))
        {
            // Collecting animation
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            collectedItems.Add(rb);
            Vector2 forceDirection = (transform.position - collision.gameObject.transform.position).normalized;
            rb.AddForce(-forceDirection * magnetAnimationStrength, ForceMode2D.Impulse);
            

            //collectible.Collect();
        }
    }
}
