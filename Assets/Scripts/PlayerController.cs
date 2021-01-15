using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    private bool isGrounded;
    private bool canDoubleJump;

    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public float knockbackCounter;
    public float knockbackLength;
    public int knockbackForce;
    public int bounceForce;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        CheckpointController.instance.SetSpawnPoint(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCounter <= 0)
        {
            _rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), _rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, groundLayer);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                    AudioManager.instance.PlaySoundEffect("Player Jump");
                }
                else
                {
                    if (canDoubleJump)
                    {
                        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                        AudioManager.instance.PlaySoundEffect("Player Jump");
                        canDoubleJump = false;
                    }
                }
            }

            if (_rb.velocity.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_rb.velocity.x < 0)
            {
                _spriteRenderer.flipX = true;
            }

            _animator.SetBool("isGrounded", isGrounded);
            _animator.SetFloat("moveSpeed", Math.Abs(_rb.velocity.x));
        }
        else
        {
            knockbackCounter -= Time.deltaTime;

            if (_spriteRenderer.flipX)
            {
                _rb.velocity = new Vector2(knockbackForce, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = new Vector2(-knockbackForce, _rb.velocity.y);
            }
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        _rb.velocity = new Vector2(0f, _rb.velocity.y);
        _animator.SetTrigger("hurt");
    }

    public void StopKnockback()
    {
        knockbackCounter = 0;
    }

    public void Bounce()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, bounceForce);
    }
}
