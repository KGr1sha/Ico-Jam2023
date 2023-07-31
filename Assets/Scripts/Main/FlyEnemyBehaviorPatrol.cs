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
                if (_facingDirection == LEFT)
                {
                    ChangeDirection(enemy, RIGHT);
                }
                else
                {
                    ChangeDirection(enemy, LEFT);
                }
            }
        }

        private void ChangeDirection(FlyingEnemyStates enemy, string newDirecrion)
        {
            _facingDirection = newDirecrion;
        }

        private void Move(FlyingEnemyStates enemy)
        {
            var vX = enemy.patrolSpeed;
            if (_facingDirection == RIGHT)
                vX = -enemy.patrolSpeed;
            _rigidbody.velocity = new Vector2(vX, _rigidbody.velocity.y);
        }
    }
}