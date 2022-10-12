namespace PacMan
{
    public class ChaseEnemyState : IEnemyState
    {
        private ChaseStrategy _strategy;
        private IEnemyAgent _agent;
        private readonly float _ticks;
        private float _ticksTimer;
        public bool CanBeConsumed => false;
        public bool CanConsume => true;
        public float SpeedMultiplier => 1;
        public EnemyAgentStatus State => EnemyAgentStatus.Normal;

        public ChaseEnemyState(ChaseStrategy strategy, IEnemyAgent agent, float ticks)
        {
            _strategy = strategy;
            _agent = agent;
            _ticks = ticks;
        }

        public void Enter()
        {
            if (_ticksTimer >= _ticks)
            {
                _ticksTimer = 0;
            }
        }

        public void Update(float ticks)
        {
            _ticksTimer += ticks;
            _agent.Movement.SetTarget(_strategy.GetTarget(_agent));
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