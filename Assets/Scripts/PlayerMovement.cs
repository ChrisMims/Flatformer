using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using QFSW.QC;

public class PlayerMovement : MonoBehaviour
{
    public MMFeedbacks playerJumpFeedback, playerDoubleJumpFeedback, playerMoveFeedback, playerLandFeedback;

    private Rigidbody2D rb;
    private CircleCollider2D playerCollider;
    private SpriteRenderer sprite;

    private bool isDoubleJumpAvailable;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float gravityScale;

    private float xAxis = 0f;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect, doubleJumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(xAxis * movementSpeed, rb.velocity.y);
        
        CalculateJump();
        MovePlayer();
        UpdateAnimationState();
    }
    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    private void CalculateJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isDoubleJumpAvailable = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (jumpSoundEffect != null)
            {
                jumpSoundEffect.Play();
            }

            playerJumpFeedback?.PlayFeedbacks();
        }
        else if (Input.GetButtonDown("Jump") && isDoubleJumpAvailable && !IsGrounded())
        {
            isDoubleJumpAvailable = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (jumpSoundEffect != null)
            {
                doubleJumpSoundEffect.Play();
            }

            playerDoubleJumpFeedback?.PlayFeedbacks();
        }

    }
    private void MovePlayer()
    {
        xAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * xAxis * Time.deltaTime * movementSpeed);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (xAxis > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (xAxis < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size,
            0f, Vector2.down, .1f, jumpableGround);
    }
}