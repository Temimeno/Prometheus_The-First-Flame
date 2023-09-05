using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 8f;
    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    GameOver gameOver;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        animator.SetFloat("Horizontal", horizontal);
    }

    private void FixedUpdate()
    {
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

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("Let the fisrt flame rise");
        gameOver = FindObjectOfType<GameOver>();
        gameOver.GameEnd();
    }
}
