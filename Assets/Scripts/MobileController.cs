using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private bool isJumping = false;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { Idle, Running, Jumping, Falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>(); // Corrected access to the Animator component.
        sprite = GetComponent<SpriteRenderer>(); // Corrected access to the SpriteRenderer component.
    }

    private void Update()
    {
        if (isMovingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (isMovingLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (isJumping && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (rb.velocity.x > 0.1f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (rb.velocity.x < -0.1f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    public void OnJumpButtonClicked()
    {
        isJumping = true;
    }

    public void OnRightButtonClicked()
    {
        isMovingRight = true;
    }

    public void OnRightButtonReleased()
    {
        isMovingRight = false;
    }

    public void OnLeftButtonClicked()
    {
        isMovingLeft = true;
    }

    public void OnLeftButtonReleased()
    {
        isMovingLeft = false;
    }
}
