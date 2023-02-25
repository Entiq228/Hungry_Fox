using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Գ����
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    //��������
    public LayerMask roof;
    public Collider2D poseStand;
    public Collider2D poseSquad;
    public Transform topCheck;
    public float topCheckRadius;
    public float speedStatic;
    private bool crounchAbility = true;

    //³�����������
    private bool facingRight = true;

    //�������
    public Transform groundCheck;
    private bool isGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool jumpAbility = true;

    //�������
    public Transform ladderCheck;
    private bool isLadder;
    public float ladderCheckRadius;
    public LayerMask ladder;
    public float climbingSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedStatic = speed;
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isLadder = Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, ladder);

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }

        //��������
        if (Input.GetKey(KeyCode.S) && crounchAbility == true)
        {
            poseStand.enabled = false;
            poseSquad.enabled = true;
            jumpAbility = false;
        }
        else if (!Physics2D.OverlapCircle(topCheck.position, topCheckRadius, roof))
        {
            poseStand.enabled = true;
            poseSquad.enabled = false;
            jumpAbility = true;
        }

    }
    private void Update()
    {
        //������
        if (isGround == true && Input.GetKey(KeyCode.Space) && jumpAbility)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        //�������� ��������
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = speed * 0.75f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            speed = speedStatic;
        }
        //������� �� ������
        if (isLadder == true)
        {
            rb.gravityScale = 0;
            jumpAbility = false;
            crounchAbility = false;
            rb.velocity = Vector2.up * 0;
        }
        else if (isLadder == false)
        {
            rb.gravityScale = 3;
            jumpAbility = true;
            crounchAbility = true;
        }
        //ϳ���� �����
        if (isLadder == true && Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector2.up * climbingSpeed;
        }
        
        //����� �� ����
        if(isLadder == true && Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector2.up * -climbingSpeed;
        }
        

    }
    //�������� ���������
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
