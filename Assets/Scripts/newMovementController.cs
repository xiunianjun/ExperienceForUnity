using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovementController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    public float moveSpeed = 3.0f;
    Vector2 movement = new Vector2();
    public bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(movement.x, 0))
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
            if (movement.x>0)
            {
                isRight = true;
            }
            else
            {
                isRight = false;
            }
        }
        animator.SetFloat("runningDirection", movement.x);
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        //movement.Normalize();
        rb2d.velocity = new Vector2(moveSpeed * movement.x, rb2d.velocity.y);
    }
}
