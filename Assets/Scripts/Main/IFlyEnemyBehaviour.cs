namespace Assets.Scripts.Main
{
    public interface IFlyEnemyBehaviour
    {
        void Enter(FlyingEnemyStates enemy);
        void Exit(FlyingEnemyStates enemy);
        void Update(FlyingEnemyStates enemy);
    }
}