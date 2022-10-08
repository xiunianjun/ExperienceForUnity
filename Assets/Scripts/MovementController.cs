using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    public float moveSpeed = 3.0f;
    Vector2 movement = new Vector2();
    bool onGround;
    public float jumpVelocity;
    bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(movement.x,0))
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        animator.SetFloat("runningDirection", movement.x);
        if (onGround&&Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        if (!onGround)
        {
            animator.SetBool("isJump", false);
        }
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.Normalize();
        rb2d.velocity = movement * moveSpeed;
        if (isJump)
        {
            animator.SetBool("isJump", true);
            rb2d.AddForce(Vector2.up * jumpVelocity,ForceMode2D.Impulse);
            isJump = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }
}
