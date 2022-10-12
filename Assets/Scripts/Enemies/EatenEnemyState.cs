using UnityEngine;

namespace PacMan
{
    public class EatenEnemyState : IEnemyState
    {
        private readonly Vector2Int _defaultPosition;
        private IMovingAgent _agent;

        public bool CanBeConsumed => false;
        public bool CanConsume => false;
        public float SpeedMultiplier => 2;
        public EnemyAgentStatus State => EnemyAgentStatus.Consumed;

        public EatenEnemyState(Vector2Int defaultPosition, IMovingAgent agent)
        {
            _defaultPosition = defaultPosition;
            _agent = agent;
        }

        public void Enter()
        {
            _agent.Movement.SetTarget(_defaultPosition);
        }

        public void Update(float ticks)
        {

        }

        public bool CanMoveToNextState()
        {
            return _agent.Movement.CurrentPosition == _defaultPosition;
        }

        public void ResetState()
        {

        }
    }
}