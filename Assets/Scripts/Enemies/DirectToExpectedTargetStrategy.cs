using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName="ChaseAheadTarget", menuName = "Chase Strategies/Ahead Target")]
    public class DirectToExpectedTargetStrategy : ChaseStrategy
    {
        public override Vector2Int GetTarget(IEnemyAgent agent)
        {
            return agent.Target.Movement.CurrentPosition + agent.Target.Movement.CurrentDirection.ToVector() * 4;
        }
    }
}