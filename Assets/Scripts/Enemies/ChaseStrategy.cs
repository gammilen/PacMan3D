using UnityEngine;

namespace PacMan
{
    public abstract class ChaseStrategy : ScriptableObject
    {
        public abstract Vector2Int GetTarget(IEnemyAgent agent);
    }
}