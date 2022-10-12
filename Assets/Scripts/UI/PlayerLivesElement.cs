using PacMan;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerLivesElement : MonoBehaviour
    {
        [SerializeField] private PlayerLives _playerLives;
        [SerializeField] private Text _counterText;

        private void OnEnable()
        {
            _playerLives.LivesChanged += HandleLivesChanged;
        }

        private void HandleLivesChanged()
        {
            _counterText.text = _playerLives.CurrentLives.ToString();
        }
    }
}