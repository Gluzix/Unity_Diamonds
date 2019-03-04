using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    private bool in_the_air = false;
    private bool check_space = false;
    private int iterator = 0;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal"); 
        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if(isGrounded)
        {
            anim.SetBool("isGround", true);
            if (iterator > 20)
            {
                in_the_air = false;
                iterator = 0;
            }
        }
        else if(isGrounded == false && in_the_air == true)
        {
            anim.SetBool("isGround", false);
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } 
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            in_the_air = true;
        }
        if(in_the_air==true) iterator++;

        if(Input.GetKeyDown(KeyCode.Space) && check_space==false)
        {
            jumpForce *= 2;
            check_space = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && check_space == true)
        {
            jumpForce /= 2;
            check_space = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
