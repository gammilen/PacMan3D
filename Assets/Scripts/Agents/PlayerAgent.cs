using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="PlayerAgent", menuName ="Entities/Player Agent")]
    public class PlayerAgent : ScriptableObject, IActiveEntity, IMovingAgent, IConsumableConsumer
    {
        private IMovementUpdater _movementUpdater;
        private AgentStepTickValue _stepValue;
        private IConsuming _consuming;
        private PositionInteractionActionSource _actions;

        public Vector2Int Position => Movement.CurrentPosition;
        public Movement Movement { get; private set; }
        public IStepTickValue StepTickValue => _stepValue;
        public bool CanBeConsumed => true;

        public void Init(IMovementUpdater movementUpdater, Movement movement, IConsuming consuming,
            AgentStepTickValue stepValue, PositionInteractionActionSource actions)
        {
            Movement = movement;
            _consuming = consuming;
            _movementUpdater = movementUpdater;
            _stepValue = stepValue;
            _actions = actions;
        }

        public void Move()
        {
            _actions.Act(this);
            _movementUpdater.UpdateTarget(Movement);
            Movement.MoveToTarget();
        }

        public void BeConsumed()
        {
            _consuming.Consume();
        }

        public bool CanConsume(IConsumable consumable)
        {
            return true;
        }

        public void Consume(IConsumable consumable)
        {
            
        }
    }
}