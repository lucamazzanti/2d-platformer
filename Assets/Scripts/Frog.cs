using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public int moveSpeed;

    private float waitCount, moveCount;
    public int waitTime, moveTime;

    public Transform leftLimit, rightLimit;

    private bool faceRight;

    private Rigidbody2D _rb;

    public SpriteRenderer _SpriteRenderer;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        leftLimit.parent = null;
        rightLimit.parent = null;

        waitCount = waitTime;
        _animator.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            if (faceRight)
            {
                _SpriteRenderer.flipX = true;

                _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);

                if (gameObject.transform.position.x > rightLimit.position.x)
                {
                    faceRight = false;
                }
            }
            else
            {
                _SpriteRenderer.flipX = false;

                _rb.velocity = new Vector2(-moveSpeed, _rb.velocity.y);

                if (gameObject.transform.position.x < leftLimit.position.x)
                {
                    faceRight = true;
                }
            }

            moveCount -= Time.deltaTime;

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);

                _animator.SetBool("isMoving", false);
            }
        } 
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;

            _rb.velocity = new Vector2(0f, _rb.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, moveTime * 1.25f);

                _animator.SetBool("isMoving", true);
            }
        }
    }
}
