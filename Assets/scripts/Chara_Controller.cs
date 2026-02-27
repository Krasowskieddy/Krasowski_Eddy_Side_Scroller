using UnityEngine;

public class Chara_Controler : MonoBehaviour
{
    [Header("Move variables")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 20f;

    [Header("Gravity/jump")]
    [SerializeField] float gravity = -10f;
    [SerializeField] float jumpForce = 1.5f;

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
