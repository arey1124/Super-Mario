using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5f;
    public Transform groundCheckPosition;

    private Rigidbody2D myBody;
    private Animator animator;
    private bool jump;
    private float jumpPower = 5f;

    private bool isGrounded;
    public LayerMask groundLayer;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start() {
        
    }

    void Update() {
        CheckIfIsGrounded();
        PlayerJump();
    }

    void FixedUpdate() {
        PlayerWalk();
    }

    void PlayerWalk() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0) {
            myBody.velocity = new Vector2 (speed, myBody.velocity.y);
            ChangeDirection(1);
        } else if (horizontal < 0) {
            myBody.velocity = new Vector2 (-speed, myBody.velocity.y);
            ChangeDirection(-1);
        } else {
            myBody.velocity = new Vector2 (0f, myBody.velocity.y);
        }

        animator.SetInteger("Speed", Mathf.Abs((int) myBody.velocity.x));
    }

    void ChangeDirection(int direction) {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;

    }

    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Ground") {
            print("Collided with ground");
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        
    }

    void CheckIfIsGrounded() {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);
        if(isGrounded) {
            if(jump) {
                jump = false;
                animator.SetBool("Jump", false);
            }
        }
    }

    void PlayerJump() {
        if(isGrounded){
            if(Input.GetKey(KeyCode.Space)) {
                jump = true;
                myBody.velocity = new Vector2 (myBody.velocity.x, jumpPower);
                animator.SetBool("Jump", true);
            }
        }
    }
}
