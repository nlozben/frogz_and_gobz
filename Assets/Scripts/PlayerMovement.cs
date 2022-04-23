using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private float horizontal;
    private float speed = 20f;
    private float jumpingPower = 40f;
    public bool isFacingRight;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            FindObjectOfType<AudioManager>().play("Jump");
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, 0.2f, groundLayer);
        if (isTouchingFront && !isGrounded() && horizontal != 0f) {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, 0f, float.MaxValue));
        }
        
        if (Input.GetButtonDown("Jump") && isTouchingFront && !isGrounded() && horizontal != 0f) {
            wallJumping = true;
            Invoke("setWallJumpToFalse", wallJumpTime);
        }
        
        if (wallJumping) {
            FindObjectOfType<AudioManager>().play("Jump");
            rb.velocity = new Vector2(xWallForce * -horizontal, yWallForce);
        }
        Flip();
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void setWallJumpToFalse() {
        wallJumping = false;
    }

}
