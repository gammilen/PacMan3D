using System.Collections;
using UnityEngine;
using PacMan;

namespace Game
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private PacMan.Game _game;

        private GameObject _currentLevelObj;

        private void Awake()
        {
            _level.LevelChanged += InitLevel;
            _game.StartGame();
        }

        private void InitLevel()
        {
            StartCoroutine(WaitAndInit());
        }

        private IEnumerator WaitAndInit()
        {
            yield return new WaitForSeconds(0.1f);
            if (_currentLevelObj != null)
            {
                Destroy(_currentLevelObj);
                _currentLevelObj = null;
            }
            _currentLevelObj = Instantiate(_levelPrefab, transform);
        }
    }
}