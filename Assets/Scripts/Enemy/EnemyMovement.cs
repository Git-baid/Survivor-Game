using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;

    EnemyStats enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(rb.velocity.magnitude < enemy.currentMaxSpeed)
            rb.AddForce((player.position - transform.position).normalized * enemy.currentMoveSpeed, ForceMode2D.Force); // physics based movement
        //transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.EnemyMoveSpeed * Time.deltaTime); // transform based movement
    }
}
