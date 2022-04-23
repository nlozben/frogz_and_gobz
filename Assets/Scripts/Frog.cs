using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    
    float speed = 5f;
    float jumpingPower = 10f;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform frontCheck;
    public LayerMask groundLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (isTouchingFront() && Random.Range(0, 3) == 2) {
            speed = -speed;
        }
        else if (isTouchingFront() && isGrounded()) {
            rb.velocity = new Vector2(speed*3, jumpingPower*4);
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isTouchingFront() {
        return Physics2D.OverlapCircle(frontCheck.position, 0.2f, groundLayer);
    }

}
