using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 6.0f;
    public float speed = 6.0f;
    public float moveDirect;

    bool jump;
    bool grounded;
    bool moving;

    SpriteRenderer spRender;
    Rigidbody2D rb;
    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spRender = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (rb.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rb.velocity = new Vector2(speed * moveDirect, rb.velocity.y);

        if (jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }    
    }

    void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D))))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirect = -1.0f;
                spRender.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirect = 1.0f;
                spRender.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirect = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                jump = true;
                grounded = false;
                anim.SetTrigger("jump");
                anim.SetBool("grounded", false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirect = -1.0f;
                spRender.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirect = 1.0f;
                spRender.flipX = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && grounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, -10.0f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
    }
}