using System.Collections;
using UnityEngine;
using PacMan;

namespace Game
{
    public class AgentsSpawner : MonoBehaviour
    {
        [SerializeField] private AgentTickersSynchronizer _tickersSynchronizer;
        [SerializeField] private PlayerAgentRegistrar _playerRegistrar;
        [SerializeField] private CellsField _cellsField;
        [SerializeField] private EnemiesAgentsRegistry _enemiesAgentsRegistry;
        [SerializeField] private AgentsVisuals _agentsVisual;


        private void Start()
        {
            InitPlayer();
            foreach (var enemy in _enemiesAgentsRegistry.Enemies)
            {
                InitAgent(enemy, _agentsVisual.GetForEnemy(enemy.EnemyData));
            }
            _tickersSynchronizer.StartTicking();
        }

        private void InitPlayer()
        {
            InitAgent(_playerRegistrar.Agent, _agentsVisual.PlayerVisual);
        }

        private void InitAgent(IMovingAgent movingAgent, AgentsVisuals.AgentVisual visual)
        {
            var agent = Instantiate(visual.Prefab, transform);
            var ticker = new AgentTicker(movingAgent);
            _tickersSynchronizer.AddTicker(ticker);
            agent.transform.position = _cellsField.GetAgentPosition(movingAgent.Movement.CurrentPosition);
            agent.Setup(ticker, _cellsField);
            agent.GetComponent<Renderer>().material.color = visual.Color;
        }
    }
}