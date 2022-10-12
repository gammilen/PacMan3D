namespace PacMan
{
    public interface IEnemyState
    {
        bool CanBeConsumed { get; }
        bool CanConsume { get; }
        float SpeedMultiplier { get; }
        EnemyAgentStatus State { get; }
        void Enter();
        void Update(float ticks);
        bool CanMoveToNextState();
        void ResetState();
    }
}