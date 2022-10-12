using System;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName = "CurrentLevel", menuName = "Services/Current Level")]
    public class CurrentLevel : ScriptableObject
    {
        [SerializeField] private LevelActivation _activation;

        public Level Level { get; private set; }
        public int Number { get; private set; }
        public event Action LevelChanged;

        private void OnEnable()
        {
            _activation.ActivateEvent += Activate;
        }

        private void Activate(Level level, int number)
        {
            Debug.Log("activate curr level");
            Number = number;
            Level = level;
            LevelChanged?.Invoke();
        }
    }
}