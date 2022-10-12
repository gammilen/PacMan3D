using System;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName = "LevelActivation", menuName = "Services/LevelActivation")]
    public class LevelActivation : ScriptableObject
    {
        public event Action<Level, int> ActivateEvent;
        public int Counter { get; private set; }

        public void ChangeLevel(Level newLevel)
        {
            Counter++;
            ActivateEvent?.Invoke(newLevel, Counter);
        }

        public void ResetCounter()
        {
            Counter = 0;
        }
    }
}