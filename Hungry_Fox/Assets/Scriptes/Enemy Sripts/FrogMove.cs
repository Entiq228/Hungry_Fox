using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    private bool facingRight = false;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGround;

    private Rigidbody2D rb;
    public float jumpForceHorizontal;
    public float jumpForceVertical;

    public float IdleTime;
    private float currentIdleTime = 0f;
    public bool isIdle = true;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGround == true)
        {
            isIdle = true;
        }

        if (isIdle == true)
        {
            currentIdleTime += Time.deltaTime;
            if(currentIdleTime >= IdleTime && isGround == true)
            {
                currentIdleTime = 0f;
                Flip();
                Jump();
            }
        }
    }
    public void Jump()
    {
        isIdle = false;
        float direction = 0;
        if (facingRight == true)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }
        rb.velocity = new Vector2(jumpForceHorizontal * direction, jumpForceVertical);
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
}
