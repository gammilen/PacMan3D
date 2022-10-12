using System;
using UnityEngine;

namespace PacMan
{
    public class EnemyAgent : IActiveEntity, IConsumableConsumer, IEnemyAgent
    {
        private IConsuming<LevelEnemy> _consuming;
        private EnemyStatesMachine _states;
        public AgentStepTickValue _stepValue;
        private PositionInteractionActionSource _actions;

        public event Action<EnemyAgent> Consumed;
        public IStepTickValue StepTickValue => _stepValue;
        public Vector2Int Position => Movement.CurrentPosition;
        public Movement Movement { get; }
        public Enemy EnemyData => LevelEnemyData.Enemy;
        public IMovingAgent Target { get; }
        public LevelEnemy LevelEnemyData { get; }


        bool IConsumable.CanBeConsumed => _states.CurrentState.CanBeConsumed;

        public EnemyAgent(LevelEnemy levelEnemy, IConsuming<LevelEnemy> consuming, 
            Movement movement, AgentStepTickValue stepValue,
            EnemyStatesFactory statesFactory, IMovingAgent target, PositionInteractionActionSource actions)
        {
            Target = target;
            LevelEnemyData = levelEnemy;
            _consuming = consuming;
            Movement = movement;
            _actions = actions;
            _stepValue = stepValue;
            _states = statesFactory.GetEnemyStatesMachine(this);
        }

        public void Move()
        {
            _actions.Act(this);
            _states.Update(_stepValue.GetValue());
            _stepValue.SpeedMultiplier = _states.CurrentState.SpeedMultiplier;
            Movement.MoveToTarget();
        }

        public void BeConsumed()
        {
            _consuming.Consume(LevelEnemyData);
            Consumed?.Invoke(this);
            _states.BeConsumed();
        }

        public void BeFrightened()
        {
            _states.BeFrightened();
        }

        public bool CanConsume(IConsumable consumable)
        {
            return _states.CurrentState.CanConsume && ReferenceEquals(Target, consumable);
        }

        public void Consume(IConsumable consumable)
        {
            
        }
    }
}