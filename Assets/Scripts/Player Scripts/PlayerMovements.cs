using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private Animator animator;


    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start() {
        
    }

    void Update() {
        
    }

    void FixedUpdate() {
        PlayerWalk();
    }

    void PlayerWalk() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0) {
            myBody.velocity = new Vector2 (speed, myBody.velocity.y);
        } else if (horizontal < 0) {
            myBody.velocity = new Vector2 (-speed, myBody.velocity.y);
        } else {
            myBody.velocity = new Vector2 (0f, myBody.velocity.y);
        }

        animator.SetInteger("Speed", Mathf.Abs((int) myBody.velocity.x));
    }
}
