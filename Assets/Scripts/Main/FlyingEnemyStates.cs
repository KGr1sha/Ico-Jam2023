using Assets.Scripts.Main;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyStates : MonoBehaviour
{
    public Transform PlayerTransform => _mainScript.playerTransform;
    public float patrolSpeed => _mainScript.PatrolSpeed;
    public float patrolRange => _mainScript.PatrolRange;
    public float chaseSpeed => _mainScript.ChaseSpeed;
    public float groundLayer => _mainScript.GroundLayer;

    private Dictionary<Type, IFlyEnemyBehaviour> _begavioursMap;
    private IFlyEnemyBehaviour _currentBehaviour;
    private FlyEnemy _mainScript;

    public void SetBehaviourPatrol()
    {
        var behaviour = GetBehaviour<FlyEnemyBehaviorPatrol>();
        SetBehaviour(behaviour);
    }

    public void SetBehaviourAgressive()
    {
        var behaviour = GetBehaviour<FlyEnemyBehaviorAgressive>();
        SetBehaviour(behaviour);
    }

    private void Start()
    {
        _mainScript = GetComponent<FlyEnemy>();

        InitBehaviours();
        SetDefaultBehaviour();
    }

    private void InitBehaviours()
    {
        _begavioursMap = new Dictionary<Type, IFlyEnemyBehaviour>();

        _begavioursMap[typeof(FlyEnemyBehaviorPatrol)] = new FlyEnemyBehaviorPatrol();
        _begavioursMap[typeof(FlyEnemyBehaviorAgressive)] = new FlyEnemyBehaviorAgressive();
    }

    private void SetBehaviour(IFlyEnemyBehaviour newBehaviour)
    {
        if (_currentBehaviour != null)
            _currentBehaviour.Exit(this);

        _currentBehaviour = newBehaviour;
        _currentBehaviour.Enter(this);
    }

    private void SetDefaultBehaviour()
    {
        SetBehaviourPatrol();
    }

    private IFlyEnemyBehaviour GetBehaviour<T>() where T : IFlyEnemyBehaviour
    {
        var behaviour = typeof(T);
        return _begavioursMap[behaviour];
    }

    private void Update()
    {
        if (_currentBehaviour != null)
            _currentBehaviour.Update(this);
    }
}
