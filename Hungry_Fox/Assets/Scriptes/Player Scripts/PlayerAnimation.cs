using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Transform topCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ladderCheck;
    public float topCheckRadius;
    public float groundCheckRadius;
    public float ladderCheckRadius;
    public LayerMask roof;
    public LayerMask ground;
    public LayerMask ladder;
    private Animator anim;
    private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        //Біг
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("StartRun", true);
        }
        else
        {
            anim.SetBool("StartRun", false);
        }
        //Повзання
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Crouch", true);
        }
        else if (!Physics2D.OverlapCircle(topCheck.position, topCheckRadius, roof))
        {
            anim.SetBool("Crouch", false);
        }
        //Стрибок і падіння
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
        //Лазання по драбині
        if(Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, ladder))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
            anim.SetBool("Crouch", false);
            anim.SetBool("LadderHold", true);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            && Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, ladder))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
            anim.SetBool("Crouch", false);
            anim.SetBool("LadderHold", false);
            anim.SetBool("LadderClimbing", true);
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            && Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, ladder))
        {
            anim.SetBool("LadderHold", true);
            anim.SetBool("LadderClimbing", false);
        }
        if (!Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, ladder))
        {
            anim.SetBool("LadderHold", false);
            anim.SetBool("LadderClimbing", false);
        }
    }
}
