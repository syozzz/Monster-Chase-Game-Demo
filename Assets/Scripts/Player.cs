using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private bool isJumping = false;

    private float movementX = 0;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    

    void Awake()
    {
        //init component
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump 放 update 防止按跳跃键失效
        Jump();
    }

    void FixedUpdate()
    {
        movementX = Input.GetAxis("Horizontal");
        Move();
        AnimatePlayer();
    }

    private void Move()
    {
        transform.Translate(new Vector2(movementX, 0f) * moveForce * Time.deltaTime);
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(Constant.WALK_ANIMATION_NAME, true);
        }
        else if (movementX < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(Constant.WALK_ANIMATION_NAME, true);
        }
        else
            _animator.SetBool(Constant.WALK_ANIMATION_NAME, false);

    }

    //jump when user enter the space key
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            _rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Constant.TAG_GROUND_NAME))
            isJumping = false;

        if (collision.gameObject.CompareTag(Constant.TAG_ENEMY_NAME))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constant.TAG_ENEMY_NAME))
            Destroy(gameObject);
        
    }
}
