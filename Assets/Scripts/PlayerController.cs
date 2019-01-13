using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    [Range(1, 10)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rb;
    float groundRadius = 0.4f;
    public bool facingRight = true;
    Animator anim;
    bool grounded = true;
    public int jumpCount;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpCount = 5;
    }

    // Update is called once per frame
    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("ground", grounded);

        anim.SetFloat("vSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0 && !facingRight) {
            Flip();
        } else if (move < 0 && facingRight) {
            Flip();
        }
    }

    void Update() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.UpArrow)) {
            anim.SetBool("ground", false);

            jumpCount--;

            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }

    public void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
