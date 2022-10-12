using UnityEngine;

namespace PacMan
{
    public class ScatterEnemyState : IEnemyState
    {
        public bool CanBeConsumed => false;
        public bool CanConsume => true;
        public float SpeedMultiplier => 1;
        public EnemyAgentStatus State => EnemyAgentStatus.Normal;

        private readonly Vector2Int _scatterPosition;
        private IMovingAgent _agent;
        private readonly float _ticks;
        private float _ticksTimer;

        public ScatterEnemyState(Vector2Int scatterPosition, IMovingAgent agent, float ticks)
        {
            _scatterPosition = scatterPosition;
            _agent = agent;
            _ticks = ticks;
        }

        public void Enter()
        {
            if (_ticksTimer >= _ticks)
            {
                _ticksTimer = 0;
            }
            _agent.Movement.SetTarget(_scatterPosition);
        }

        public void Update(float ticks)
        {
            _ticksTimer += ticks;
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