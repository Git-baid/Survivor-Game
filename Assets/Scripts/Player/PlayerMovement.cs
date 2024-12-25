using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMoveDir;

    PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir != Vector2.zero )
        {
            lastMoveDir = moveDir;
        }
    }

    private void Move()
    {
        //rb.velocity = new Vector2(moveDir.x * characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed);
        if (rb.velocity.magnitude < player.currentMaxSpeed)
            rb.AddForce(moveDir * player.currentMoveSpeed, ForceMode2D.Force);
    }
}
