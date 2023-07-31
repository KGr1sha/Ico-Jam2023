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
            
        }

        

        private void Move(FlyingEnemyStates enemy)
        {
            
        }
    }
}