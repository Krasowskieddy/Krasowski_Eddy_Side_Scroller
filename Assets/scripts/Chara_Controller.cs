using System;
using System.Collections;
using UnityEngine;

public class Chara_Controler : MonoBehaviour
{
    public Transform chara;
    public Transform boostPlace;

    [Header("Move variables")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dash = 100f;
    private bool canDash = true;
    [SerializeField] float maxJump = 1;

    // set de toute les variables de compétences
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

        if (Input.GetButtonDown("Jump") && maxJump >0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            maxJump --;
        }
        if (isBoosted == true)
        {
            jumpForce = 15f;
        }

        if (Vector2.Distance(chara.position, boostPlace.position) < 10f)
        {
            isBoosted = true;
        }
        if (isGrounded)
        {
            maxJump = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            canDash = false;
            rb.AddForce(new Vector2(inputX * dash, 0f), ForceMode2D.Impulse);
            StartCoroutine(DashCooldown());
        }

    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        canDash = true;
    }

    private void FixedUpdate()
    {
        var v = rb.linearVelocity;
        if (canDash) v.x = inputX * moveSpeed;

        rb.linearVelocity = v;

       
    }
}
