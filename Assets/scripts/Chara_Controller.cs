using System;
using System.Collections;
using UnityEngine;

public class Chara_Controler : MonoBehaviour
{
    public Transform chara;
    public Transform boostPlace;
    public Transform dashPlace;
    public GameObject player;
    public Transform respawnPoint;



    [Header("Move variables")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dash = 100f;            
    [SerializeField] float Hp = 1f;
    [SerializeField] float Dmg = 1f;
    private bool bDash = true;
    private float maxDash = 1;
    [SerializeField] float maxJump = 0;

    // set de toute les variables de compétences
    private bool isBoosted = false;
    private bool canDash = false;

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
        GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        inputX = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down,2f, groundLayer);

        if (Input.GetButtonDown("Jump") && maxJump >0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            maxJump --;
        }
        if (isBoosted == true)
        {
            jumpForce = 15f;
        }

        if (Vector2.Distance(chara.position, boostPlace.position) < 5f)
        {
            isBoosted = true;
            player.transform.position = respawnPoint.position;
        }
        if (Vector2.Distance(chara.position, dashPlace.position) < 5f)
        {
           canDash = true;
           player.transform.position = respawnPoint.position;
        }

        if (isGrounded)
        {
            Debug.Log("Grounded");
            maxJump = 1;
            maxDash = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && maxDash>0 && canDash)
        {
            bDash = false;
            rb.AddForce(new Vector2(inputX * dash, 0f), ForceMode2D.Impulse);
            StartCoroutine(DashCooldown());
            maxDash --;
        }
    }
    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        bDash = true;
    }

    private void FixedUpdate()
    {
        var v = rb.linearVelocity;
        if (bDash) v.x = inputX * moveSpeed;

        rb.linearVelocity = v;

       
    }
}
