using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Transform topCheck;
    [SerializeField] private Transform groundCheck;
    public float topCheckRadius;
    public float groundCheckRadius;
    private Animator anim;
    public LayerMask roof;
    public LayerMask ground;
    private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("StartRun", true);
        }
        else
        {
            anim.SetBool("StartRun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Crouch", true);
        }
        else if (!Physics2D.OverlapCircle(topCheck.position, topCheckRadius, roof))
        {
            anim.SetBool("Crouch", false);
        }

        if (Input.GetKey(KeyCode.Space) && !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Jumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space) &&
            !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground)
            || !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Falling", true);
            anim.SetBool("Jumping", false);           
        }
        else if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground))
        {
            anim.SetBool("Falling", false);
        }
    }
}
