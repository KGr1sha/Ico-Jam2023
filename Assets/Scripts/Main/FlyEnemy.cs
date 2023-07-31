using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : BaseEnemy
{
    public float PatrolSpeed = 1f;
    public float PatrolRange = 2f;

    private FlyingEnemyStates _stateMachine;

    protected override void Start()
    {
        base.Start();
        _stateMachine = GetComponent<FlyingEnemyStates>();
    }

    private void Update()
    {
        
    }

    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        Debug.Log("FLIIIP");
    }
}
