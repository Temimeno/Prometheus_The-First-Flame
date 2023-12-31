using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Status status;
    public Collider2D playerHurtBox;

    // Walk
    public float moveSpeed = 8f;
    private float horizontal;
    private bool isFacingRight = true;

    // Jump
    private float jumpingPower = 21f;
    public bool isGrounded;

    // Dash
    private bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;

    // Camera
    private float _fallSpeedYDampingChangeThreshold;

    // Scene Transition
    public VectorValue startingPosition;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer trailRenderer;

    //sound
    public AudioSource audioClip;

    private void Start()
    {
        _fallSpeedYDampingChangeThreshold = CameraManager.instance._fallSpeedYDampingChangeThreshold;
        transform.position = startingPosition.intialValue;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        isGrounded = Grounded();

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetBool("isDashing", isDashing);
        animator.SetBool("isGrounded", isGrounded);

        if (isDashing == true)
        {
            return;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetTrigger("Jump");
            audioClip.Play(); 
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }

        //If we are falling past a certain speed threshold
        if (rb.velocity.y < _fallSpeedYDampingChangeThreshold &&
            !CameraManager.instance.IsLerpingYDamping &&
            !CameraManager.instance.LerpingFromPlayerFalling)
        {
            CameraManager.instance.LerpYDamping(true);
        }

        //If we are standing still or moving up
        if (rb.velocity.y >= 0f &&
            !CameraManager.instance.IsLerpingYDamping &&
            CameraManager.instance.LerpingFromPlayerFalling)
        {
            //Reser so it can be called again
            CameraManager.instance.LerpingFromPlayerFalling = false;

            CameraManager.instance.LerpYDamping(false);
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

    // private void OnTriggerEnter2D(Collider2D collider2D)
    // {
    //     Debug.Log("Let the fisrt flame rise");
    //     gameOver = FindObjectOfType<GameOver>();
    //     gameOver.GameEnd();
    // }

    private IEnumerator Dash()
    {
        // Dashing
        playerHurtBox.enabled = false;
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        audioClip.Play();
        trailRenderer.emitting = true;

        // Stop Dashing
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        playerHurtBox.enabled = true;
        
        // Dash Cooldown
        yield return new WaitForSeconds(status.dashingCooldown);
        canDash = true;
    }
}
