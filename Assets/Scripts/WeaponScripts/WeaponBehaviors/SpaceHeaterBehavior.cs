using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHeaterBehavior : MeleeWeaponBehavior
{
    List<GameObject> markedEnemies;
    float timer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
        timer = currentSpeed; // Weapon immediately deals damage once it spawns
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Prop") || other.CompareTag("Enemy")) && !markedEnemies.Contains(other.gameObject))
        {
            markedEnemies.Add(other.gameObject); // Mark the enemy to be damaged on weapon interval
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.CompareTag("Prop") || other.CompareTag("Enemy")) && markedEnemies.Contains(other.gameObject))
        {
            markedEnemies.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= currentSpeed && markedEnemies.Count > 0)
        {
            foreach (GameObject enemy in markedEnemies)
            {
                if(enemy.TryGetComponent(out EnemyStats enemyStats))
                    enemyStats.TakeDamage(currentDamage);
                else if(enemy.TryGetComponent(out BreakableProps breakable))
                    breakable.TakeDamage(currentDamage);
            }
            timer = 0;
        }
    }

}
