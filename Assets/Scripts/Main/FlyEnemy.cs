using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : BaseEnemy
{
    public float PatrolSpeed = 1f;
    public float PatrolRange = 2f;

    private FlyingEnemyStates _stateMachine;
    private Rigidbody2D _rigidbody;
    private Vector3 _baseScale;

    protected override void Start()
    {
        base.Start();
        _stateMachine = GetComponent<FlyingEnemyStates>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _baseScale = transform.localScale;
    }

    private void Update()
    {
        HandleFlip();
        CheckForPlayer();
    }

    private void HandleFlip()
    {
        Vector3 localScale = _baseScale;
        if (_rigidbody.velocity.x > 0)
        {
            localScale.x = -_baseScale.x;
        }
        Debug.Log(localScale);
        transform.localScale = localScale;
    }

    private void CheckForPlayer()
    {

    }
}
