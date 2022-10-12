using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="EnemiesRegistry", menuName ="Services/Registry")]
    public class EnemiesAgentsRegistry : ScriptableObject, IEntitiesSource
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private OnLevelEntities _onLevelEntities;
        [SerializeField] private PlayerAgent _player;

        [SerializeField] private Score _score;

        private List<EnemyAgent> _enemies = new List<EnemyAgent>();

        public IList<EnemyAgent> Enemies => _enemies;

        private void OnEnable()
        {
            _onLevelEntities.AddEntitiesSource(this);
        }

        public IEnumerable<IActiveEntity> InitEntities()
        {
            Debug.Log("init enemies");
            _enemies.Clear();
            var field = _level.Level.GetField();
            var consuming = new ScoreConsuming<LevelEnemy>(_score);
            var statesFactory = new EnemyStatesFactory(_level);
            foreach (var enemy in _level.Level.Enemies)
            {
                var agent = new EnemyAgent(enemy, consuming, new Movement(field, enemy.DefaultPosition), 
                    new AgentStepTickValue(enemy.Enemy.Speed * enemy.SpeedMultiplier), statesFactory,  _player,
                    new PositionInteractionActionSource(_onLevelEntities));
                _enemies.Add(agent);
                yield return agent;
            }
        }
    }
}