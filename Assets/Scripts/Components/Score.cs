using System;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="Score", menuName ="Services/Score")]
    public class Score : ScriptableObject
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private EventChannel _finishGameChannel;

        public int GameScore { get; private set; }
        public int LevelScore { get; private set; }

        public int CurrentScore => GameScore + LevelScore;

        public event Action ScoreChanged;

        private void OnEnable()
        {
            _level.LevelChanged += OnLevelChanged;
            _finishGameChannel.NewEvent += RecordScore;
        }

        public void AddScore(int amount)
        {
            if (amount > 0)
            {
                LevelScore += amount;
                ScoreChanged?.Invoke();
            }
        }

        public int GetHighestScore()
        {
            return PlayerPrefs.GetInt("HighestScore");
        }

        public void RecordScore()
        {
            UpdateGameScore();
            if (GameScore > GetHighestScore())
            {
                PlayerPrefs.SetInt("HighestScore", GameScore);
            }
            GameScore = LevelScore = 0;
            ScoreChanged?.Invoke();
        }

        private void OnLevelChanged()
        {
            UpdateGameScore();
        }

        private void UpdateGameScore()
        {
            GameScore += LevelScore;
            LevelScore = 0;
            ScoreChanged?.Invoke();
        }
    }
}