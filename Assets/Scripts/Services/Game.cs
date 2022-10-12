using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="Game", menuName ="Services/Game")]
    public class Game : ScriptableObject
    {
        [SerializeField] private LevelActivation _levelActivation;
        [SerializeField] private List<Level> _levelOrders;
        [SerializeField] private EventChannel _gameFinishChannel;
        [SerializeField] private EventChannel _levelFinishedChannel;

        private void OnEnable()
        {
            _gameFinishChannel.NewEvent += OnGameFinish;
            _levelFinishedChannel.NewEvent += OnLevelFinish;
        }

        public void StartGame()
        {
            if (_levelOrders.Count == 0)
            {
                throw new System.Exception("No levels set for game");
            }
            _levelActivation.ResetCounter();
            TryLoadNextLevel();
        }

        private void OnGameFinish()
        {
            StartGame();
        }

        private void OnLevelFinish()
        {
            TryLoadNextLevel();
        }

        private void TryLoadNextLevel()
        {
            if (_levelOrders.Count <= _levelActivation.Counter)
            {
                _gameFinishChannel.Raise();
            }
            else
            {
                _levelActivation.ChangeLevel(_levelOrders[_levelActivation.Counter]);
            }
        }

    }
}