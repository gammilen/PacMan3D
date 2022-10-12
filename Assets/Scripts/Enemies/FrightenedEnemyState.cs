namespace PacMan
{
    public class FrightenedEnemyState : IEnemyState
    {
        private IMovingAgent _agent;
        private readonly float _ticks;
        private float _ticksTimer;
        public bool CanBeConsumed => true;
        public bool CanConsume => false;
        public float SpeedMultiplier => 0.5f;
        public EnemyAgentStatus State => EnemyAgentStatus.Frightened;

        public FrightenedEnemyState(IMovingAgent agent, float ticks)
        {
            _agent = agent;
            _ticks = ticks;
        }

        public void Enter()
        {
            if (_ticksTimer >= _ticks)
            {
                _ticksTimer = 0;
            }
            _agent.Movement.SetTarget(null);
            _agent.Movement.TrySetDirection(_agent.Movement.CurrentDirection.GetOpposite());
        }

        public void Update(float ticks)
        {
            _ticksTimer += ticks;
            _agent.Movement.RandomizeDirection();
        }

        public bool CanMoveToNextState()
        {
            return _ticksTimer >= _ticks;
        }

        public void ResetState()
        {
            _ticksTimer = 0;
        }
    }
}