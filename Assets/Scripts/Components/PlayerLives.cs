using System;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="PlayerLives", menuName ="Services/Player Lives")]
    public class PlayerLives : ScriptableObject
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private EventChannel _finishGameChannel;
        
        public int CurrentLives { get; private set; }

        public event Action LivesChanged;

        private void OnEnable()
        {
            _level.LevelChanged += UpdateLives;
        }

        private void UpdateLives()
        {
            CurrentLives = _level.Level.PlayerLives;
            LivesChanged?.Invoke();
        }

        public void UseLife()
        {
            CurrentLives--;
            LivesChanged?.Invoke();
            if (CurrentLives <= 0)
            {
                _finishGameChannel.Raise();
            }
        }
    }
}