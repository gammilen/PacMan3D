using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName ="TimeSettings", menuName ="Settings/Time")]
    public class TimeSettings : ScriptableObject
    {
        [field: SerializeField, Tooltip("In seconds")]
        public float TickValue;
    }
}