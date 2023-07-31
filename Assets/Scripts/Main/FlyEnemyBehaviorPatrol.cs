using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

namespace Assets.Scripts.Main
{
    public class FlyEnemyBehaviorPatrol : IFlyEnemyBehaviour
    {
        private Vector2 _patrolPoint;
        private Rigidbody2D _rigidbody;
        private Vector2 _pointA;
        private Vector2 _pointB;
        private Vector2 _currentPoint;

        private FlyingEnemyStates _enemy;

        public void Enter(FlyingEnemyStates enemy)
        {
            _enemy = enemy;
            Debug.Log("Enter patrol state");
            _patrolPoint = enemy.transform.position;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
            InitPatrolPoints();
        }

        public void Exit(FlyingEnemyStates enemy)
        {
            Debug.Log("Exit patrol state");
        }

        public void Update(FlyingEnemyStates enemy)
        {
            Move();

            var distanceToPoint = Vector2.Distance(_enemy.transform.position, new Vector3(_currentPoint.x, _currentPoint.y, 0f));
            //Debug.Log(distanceToPoint);
            if (distanceToPoint < 0.5f)
            {
                ChangePatrolPoint();
            }
        }

        private void Move()
        {
            if (_currentPoint == _pointA)
            {
                _rigidbody.velocity = Vector2.left * _enemy.patrolSpeed;
            }
            if (_currentPoint == _pointB)
            {
                _rigidbody.velocity = Vector2.right * _enemy.patrolSpeed;
            }
        }

        private void InitPatrolPoints()
        {
            _pointA = _patrolPoint + Vector2.left * _enemy.patrolRange;
            _pointB = _patrolPoint + Vector2.right * _enemy.patrolRange;
            _currentPoint = _pointA;
        }

        private void ChangePatrolPoint()
        {
            Flip();
            if (_currentPoint == _pointA)
                _currentPoint = _pointB;
            else
                _currentPoint = _pointA;
        }

        private void Flip()
        {
            _enemy.Flip();
        }
    }
}