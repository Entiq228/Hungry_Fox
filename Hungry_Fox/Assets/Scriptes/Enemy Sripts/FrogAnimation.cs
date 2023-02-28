using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask ground;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground))
        {
            anim.SetBool("Jumping", true);
        }
        else if(Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground))
        {
            anim.SetBool("Jumping", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            anim.Play("FrogDeath");
            Destroy(gameObject, 0.3f);
        }
    }
}
