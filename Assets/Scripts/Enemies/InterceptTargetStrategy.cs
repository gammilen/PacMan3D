using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName = "ChaseInterceptTarget", menuName = "Chase Strategies/Intercept Target")]
    public class InterceptTargetStrategy : ChaseStrategy
    {
        public override Vector2Int GetTarget(IEnemyAgent agent)
        {
            var target = agent.Target.Movement.CurrentPosition + agent.Target.Movement.CurrentDirection.ToVector() * 2;

            var diff = target - agent.Movement.CurrentPosition;

            var xVector = diff.x * 2;
            var yVector = diff.y * 2;

            return new Vector2Int(agent.Movement.CurrentPosition.x + xVector, agent.Movement.CurrentPosition.y + yVector);
        }
    }
}