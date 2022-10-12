using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName = "ChaseToTargetPos", menuName = "Chase Strategies/Target Position")]
    public class DirectToTargetStrategy : ChaseStrategy
    {
        public override Vector2Int GetTarget(IEnemyAgent agent)
        {
            return agent.Target.Movement.CurrentPosition;
        }
    }
}