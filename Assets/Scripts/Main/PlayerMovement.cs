using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _jumpSound;

    private FlipPlayer _flipScript;
    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private float _horizontalInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _flipScript = GetComponent<FlipPlayer>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        HandleAnimations();
    }

    private void FixedUpdate()
    {
        MoveCharacter(_horizontalInput);
    }

    private void MoveCharacter(float direction)
    {
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);
        if (direction < 0f)
        {
            _flipScript.SetLookDirection("left");
        }
        else if (direction > 0f)
        {
            _flipScript.SetLookDirection("right");
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _jumpSound.Play();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size * 0.9f, 0, Vector2.down, 0.2f, _groundLayerMask);
        return raycast.collider != null;
    }

    private void HandleAnimations()
    {
        if (_horizontalInput != 0f)
        {
            _animator.SetBool("iswalking", true);
        }
        else
        {
            _animator.SetBool("iswalking", false);
        }

        if (IsGrounded())
        {
            _animator.SetBool("jump", false);
        }
        else
        {
            _animator.SetBool("jump", true);
        }
    }
}
