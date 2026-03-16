using System;
using UnityEngine;

public class Chara_Controler : MonoBehaviour
{
    public Transform chara;
    public Transform boostPlace;

    [Header("Move variables")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 20f;
    public bool isBoosted;
    [SerializeField] float boost = 8f;
    [Header("Gravity/jump")]
    [SerializeField] float gravity = -10f;
    public float jumpForce = 2f;
    Rigidbody2D rb;
    float inputX;
    public LayerMask groundLayer;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        inputX = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded ) rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        if (isBoosted == true)
        {
            jumpForce = 15f;
        }

        if (Vector2.Distance(chara.position, boostPlace.position) < 10f)
        {
            isBoosted = true;
        }

        /*
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
        */

    }

    private void FixedUpdate()
    {
        var v = rb.linearVelocity;
        v.x = inputX * moveSpeed;

        rb.linearVelocity = v;

       // rb.linearVelocity = input * moveSpeed;
    }
}
