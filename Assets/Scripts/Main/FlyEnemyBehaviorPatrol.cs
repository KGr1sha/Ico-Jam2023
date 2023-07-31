using UnityEngine;


namespace Assets.Scripts.Main
{
    public class FlyEnemyBehaviorPatrol : IFlyEnemyBehaviour
    {
        private Vector2 _patrolPoint;
        private Rigidbody2D _rigidbody;
        private Vector2 _pointA;
        private Vector2 _pointB;
        private Vector2 _currentPoint;
        private LayerMask _groundMask;

        private FlyingEnemyStates _enemy;

        public void Enter(FlyingEnemyStates enemy)
        {
            _enemy = enemy;
            _patrolPoint = enemy.transform.position;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
            InitPatrolPoints();
        }

        public void Exit(FlyingEnemyStates enemy)
        {
        }

        public void Update(FlyingEnemyStates enemy)
        {
            Move();
            CheckForWalls();
            var distanceToPoint = Vector2.Distance(_enemy.transform.position, new Vector3(_currentPoint.x, _currentPoint.y, 0f));

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
            if (_currentPoint == _pointA)
                _currentPoint = _pointB;
            else
                _currentPoint = _pointA;
        }

        private void CheckForWalls()
        {
            Vector2 castDir = Vector2.left;
            if (_currentPoint == _pointA)
                castDir = Vector2.left;
            if (_currentPoint == _pointB)
                castDir = Vector2.right;

            RaycastHit2D cast = Physics2D.Raycast(_enemy.transform.position, castDir, 0.2f, _groundMask);
            //Debug.DrawLine(_enemy.transform.position, _enemy.transform.position + new Vector3(castDir.x, castDir.y, 0));
            if (cast)
            {
                ChangePatrolPoint();
            }

        }
    }
}