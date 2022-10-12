using System;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="EventChannel", menuName ="Events/Event Channel")]
    public class EventChannel : ScriptableObject   
    {
        public event Action NewEvent;

        public void Raise()
        {
            NewEvent?.Invoke();
        }
    }
}