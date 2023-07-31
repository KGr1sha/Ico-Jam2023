using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class FlyEnemyBehaviorPatrol : IFlyEnemyBehaviour
    {
        private Vector2 _patrolPoint;
        private Rigidbody2D _rigidbody;

        private string LEFT = "left";
        private string RIGHT = "right";

        private string _facingDirection;

        public void Enter(FlyingEnemyStates enemy)
        {
            Debug.Log("Enter patrol state");
            _patrolPoint = enemy.transform.position;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
            _facingDirection = LEFT;
        }

        public void Exit(FlyingEnemyStates enemy)
        {
            Debug.Log("Exit patrol state");
        }

        public void Update(FlyingEnemyStates enemy)
        {
            Move(enemy);
            if (Vector2.Distance(enemy.transform.position, _patrolPoint) >= enemy.patrolRange)
            {
                ChangeDirection(enemy);
            }
        }

        private void ChangeDirection(FlyingEnemyStates enemy)
        {
            if (_facingDirection == LEFT)
                _facingDirection = RIGHT;
            else if (_facingDirection == RIGHT)
                _facingDirection = LEFT;
        }

        private void Move(FlyingEnemyStates enemy)
        {
            if (_facingDirection == LEFT)
            {
                _rigidbody.velocity = Vector2.left * enemy.patrolSpeed;
            }
            else if (_facingDirection == RIGHT)
            {
                _rigidbody.velocity = Vector2.right * enemy.patrolSpeed;
            }
        }
    }
}