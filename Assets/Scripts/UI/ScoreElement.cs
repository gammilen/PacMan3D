using UnityEngine;
using UnityEngine.UI;
using PacMan;


namespace UI
{
    public class ScoreElement : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private Text _currentScore;
        [SerializeField] private Text _highestScore;

        private void Start()
        {
            _score.ScoreChanged += HandleScoreChanged;
            HandleScoreChanged();
        }

        private void HandleScoreChanged()
        {
            _currentScore.text = _score.CurrentScore.ToString();
            _highestScore.text = _score.GetHighestScore().ToString();
        }
    }
}