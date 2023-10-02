using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    GameOver gameOver;
    public Animator animator;

    // Walk
    public float moveSpeed = 8f;
    private float horizontal;
    private bool isFacingRight = true;

    // Jump
    private float jumpingPower = 21f;
    bool isGrounded;
    public float yVelocity;

    // Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer trailRenderer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        yVelocity = rb.velocity.y;
        isGrounded = Grounded();

        animator.SetFloat("Horizontal", horizontal);
        animator.SetBool("isDashing", isDashing);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", yVelocity);

        if (isDashing == true)
        {
            return;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing == true)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    /*private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("Let the fisrt flame rise");
        gameOver = FindObjectOfType<GameOver>();
        gameOver.GameEnd();
    }*/

    private IEnumerator Dash()
    {
        // Dashing
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trailRenderer.emitting = true;

        // Stop Dashing
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        
        // Dash Cooldown
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
