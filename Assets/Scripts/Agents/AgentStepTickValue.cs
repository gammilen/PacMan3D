using UnityEditor;
using UnityEngine;

namespace PacMan
{
    public class AgentStepTickValue : IStepTickValue
    {
        private float _baseStepValue;

        public float SpeedMultiplier = 1;

        public AgentStepTickValue(float baseSpeed)
        {
            _baseStepValue = 1 / baseSpeed;
        }

        public float GetValue()
        {
            return _baseStepValue / SpeedMultiplier;
        }
    }
}