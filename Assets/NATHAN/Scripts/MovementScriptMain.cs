﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptMain : MonoBehaviour
{
    float cayoteRemember = 0;
    [SerializeField]
    float cayoteTime = 0.25f;
    float jumpStorage = 0f;
    [SerializeField]
    float jumpStorageTime = 0.25f;
    private int extraJumps;
    [SerializeField]
    private int extraJumpsValue;
    [SerializeField]
    private float jumpCut = 0.5f;
    public LayerMask ground;
    [SerializeField]
    private float jumpPower = 1f;
    private float horizontal;
    [SerializeField]
    private float moveSpeed = 1f;
    Rigidbody2D rb;

    private bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded() == true && extraJumps > 0) //jump function//
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            extraJumps--;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded() == false && extraJumps > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            extraJumps--;
        }

        Flip();

        if (Input.GetButtonUp("Jump"))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCut);
            }
        }

        if (IsGrounded() == true) //double jump resset
        {
            extraJumps = extraJumpsValue;
        }

        cayoteRemember -= Time.deltaTime;
        if (IsGrounded())
        {
            cayoteRemember = cayoteTime;
        }

        jumpStorage -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            jumpStorage = jumpStorageTime;
        }

        if ((jumpStorage > 0) && (cayoteRemember > 0))
        {
            jumpStorage = 0;
            cayoteRemember = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            facingRight = !facingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y); //basic movement//
    }

    public bool IsGrounded()
    {
        bool grounded = Physics2D.BoxCast(transform.position + new Vector3(0f, 0f, 0f), new Vector3(0.1f, 1f, 0f), 0, Vector2.down, 0.7f, ground);
        return grounded;
    }
}
