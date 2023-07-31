using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class FlyEnemyBehaviorAgressive : IFlyEnemyBehaviour
    {
        public void Enter(FlyingEnemyStates enemy)
        {
            Debug.Log("Enter agressive state");
        }

        public void Exit(FlyingEnemyStates enemy)
        {
            Debug.Log("Exit agressive state");
        }

        public void Update(FlyingEnemyStates enemy)
        {
            
        }
    }
}