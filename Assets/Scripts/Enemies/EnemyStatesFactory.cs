using UnityEngine;

namespace PacMan
{
    public class EnemyStatesFactory
    {
        [SerializeField] private CurrentLevel _level;

        public EnemyStatesFactory(CurrentLevel level)
        {
            _level = level;
        }

        public EnemyStatesMachine GetEnemyStatesMachine(IEnemyAgent agent)
        {
            return new EnemyStatesMachine(
                GetEatenState(agent),
                GetScatterState(agent),
                GetChaseState(agent),
                GetFrightenedState(agent));
        }

        private IEnemyState GetChaseState(IEnemyAgent agent)
        {
            return new ChaseEnemyState(agent.LevelEnemyData.Enemy.ChaseStrategy, agent, _level.Level.ChaseTicks);
        }

        private IEnemyState GetScatterState(IEnemyAgent agent)
        {
            return new ScatterEnemyState(agent.LevelEnemyData.ScatterPosition, agent, _level.Level.ScatterTicks);
        }

        private IEnemyState GetEatenState(IEnemyAgent agent)
        {
            return new EatenEnemyState(agent.LevelEnemyData.DefaultPosition, agent);
        }

        private IEnemyState GetFrightenedState(IEnemyAgent agent)
        {
            return new FrightenedEnemyState(agent, _level.Level.FrightenedTicks);
        }
    }
}