using UnityEngine;

namespace Assets.Scripts.Main
{
    public class FlyEnemyBehaviorAgressive : IFlyEnemyBehaviour
    {
        private Transform _playerTransform;
        private Rigidbody2D _rigidbody;

        public void Enter(FlyingEnemyStates enemy)
        {
            _playerTransform = enemy.PlayerTransform;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
        }

        public void Exit(FlyingEnemyStates enemy)
        {
        }

        public void Update(FlyingEnemyStates enemy)
        {
            Vector3 directionToPlayer = (_playerTransform.position - enemy.transform.position).normalized;
            _rigidbody.velocity = directionToPlayer * enemy.chaseSpeed;
        }
    }
}