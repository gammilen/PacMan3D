using System.Collections.Generic;
using UnityEngine;
using PacMan;

namespace Game
{
    [CreateAssetMenu(fileName ="AgentsVisuals", menuName ="Settings/Agents Visual")]
    public class AgentsVisuals : ScriptableObject
    {
        [System.Serializable]
        public class AgentVisual
        {
            [field: SerializeField] public Agent Prefab;
            [field: SerializeField] public Color Color;
        }

        [System.Serializable]
        public class EnemyAgentVisual : AgentVisual
        {
            [field: SerializeField] public Enemy Enemy;
        }
        [field: SerializeField] public AgentVisual PlayerVisual { get; private set; }
        [SerializeField] private List<EnemyAgentVisual> _enemiesVisuals;

        public AgentVisual GetForEnemy(Enemy enemy)
        {
            foreach (var visual in _enemiesVisuals)
            {
                if (visual.Enemy == enemy)
                {
                    return visual;
                }
            }
            return null;
        }
    }
}