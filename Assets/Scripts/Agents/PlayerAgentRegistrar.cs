using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    public interface IEntitiesSource
    {
        IEnumerable<IActiveEntity> InitEntities();
    }

    public class PlayerLivesConsuming : IConsuming
    {
        private readonly PlayerLives _lives;
        public PlayerLivesConsuming(PlayerLives lives)
        {
            _lives = lives;
        }

        public virtual void Consume()
        {
            _lives.UseLife();
        }
    }

    [CreateAssetMenu(fileName ="PlayerRegistrar", menuName ="Services/Player Registrar")]
    public class PlayerAgentRegistrar : ScriptableObject, IEntitiesSource
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private OnLevelEntities _onLevelEntities;

        [SerializeField] private PlayerLives _playerLives;
        [SerializeField] private PlayerAgent _player;

        public IMovingAgent Agent => _player;


        private void OnEnable()
        {
            _onLevelEntities.AddEntitiesSource(this);
        }

        public IEnumerable<IActiveEntity> InitEntities()
        {
            Debug.Log("refresh player agent registrar");
            _player.Init(new InputMovementDirector(), 
                new Movement(_level.Level.GetField(), _level.Level.PlayerPosition), 
                new PlayerLivesConsuming(_playerLives), 
                new AgentStepTickValue(_level.Level.PlayerSpeed),
                new PositionInteractionActionSource(_onLevelEntities));
            yield return _player;
        }
    }
}