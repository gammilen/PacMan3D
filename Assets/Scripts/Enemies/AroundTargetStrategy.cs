using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName = "ChaseAroundTarget", menuName = "Chase Strategies/Around Target")]
    public class AroundTargetStrategy : ChaseStrategy
    {
        public override Vector2Int GetTarget(IEnemyAgent agent)
        {
            var directToLocation = GetDirectToLocation(agent);
            return directToLocation;
        }

        private Vector2Int GetDirectToLocation(IEnemyAgent agent)
        {
            var distance = (agent.Movement.CurrentPosition - agent.Target.Movement.CurrentPosition).sqrMagnitude;
            if (distance > 64)
            {
                return agent.Target.Movement.CurrentPosition;
            }
            return agent.LevelEnemyData.ScatterPosition;
        }
    }
}