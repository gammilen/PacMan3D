using PacMan;
using System;

namespace Game
{
    public class AgentTicker
    {
        public readonly IMovingAgent Agent;
        public event Action TickEvent;

        public AgentTicker(IMovingAgent agent)
        {
            Agent = agent;
        }

        public float GetTicksForStep()
        {
            return Agent.StepTickValue.GetValue();
        }

        public void Tick()
        {
            Agent.Move();
            TickEvent?.Invoke();
        }
    }
}