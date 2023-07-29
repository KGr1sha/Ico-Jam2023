using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;

    private Rigidbody2D _rigidbody;
    private float _horizontalInput;
    private bool _isJumping;

    private void Start()
    {
        Physics2D.gravity = new Vector2(0f, -9.8f) * _gravityScale;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(_horizontalInput);
    }

    private void MoveCharacter(float direction)
    {
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isJumping = false;
        }
    }
}
