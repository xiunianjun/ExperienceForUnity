using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    public float jumpSpeed = 6.3f;
    bool onGround = true;
    newMovementController movement;

    void Start()
    {
        movement = GetComponent<newMovementController>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb2d.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
            if (movement.isRight)
            {
                animator.SetFloat("jumpDirection", 1);
            }
            else
            {
                animator.SetFloat("jumpDirection", -1);
            }
        }
        else
        {
            animator.SetBool("isJump", false);
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
