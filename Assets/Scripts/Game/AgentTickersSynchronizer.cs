using PacMan;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AgentTickersSynchronizer : MonoBehaviour
    {
        [SerializeField] private TimeSettings _timeSettings;

        private List<AgentTicker> _registeredTickers = new List<AgentTicker>();
        private List<(AgentTicker ticker, float startTickTime, float nextTickTime)> _tickersData;
        private bool _started;

        public void AddTicker(AgentTicker ticker)
        {
            if (!_registeredTickers.Contains(ticker))
            {
                _registeredTickers.Add(ticker);
            }
        }

        public float GetProgress(IMovingAgent agent)
        {
            if (!_started)
            {
                return 0;
            }
            foreach (var ticker in _tickersData)
            {
                if (ticker.ticker.Agent == agent)
                {
                    return Mathf.Clamp((GetTime() - ticker.startTickTime) / (ticker.nextTickTime - ticker.startTickTime), 0, 1);
                }
            }
            return 0;
        }

        public void StartTicking()
        {
            if (!_started)
            {
                _tickersData = new List<(AgentTicker ticker, float startTickTime, float nextTickTime)>();
                var currTime = GetTime();
                foreach (var ticker in _registeredTickers)
                {
                    _tickersData.Add((ticker, currTime, currTime + ticker.GetTicksForStep() * _timeSettings.TickValue));
                }
                _started = true;
            }
        }

        private void Update()
        {
            if (!_started) return;
            var currTime = GetTime();
            for (int i = 0; i < _tickersData.Count; i++)
            {
                (AgentTicker ticker, float startTickTime, float nextTickTime) ticker = _tickersData[i];
                if (ticker.nextTickTime <= currTime)
                {
                    ticker.ticker.Tick();
                    _tickersData[i] = (ticker.ticker, currTime, currTime + ticker.ticker.GetTicksForStep() * _timeSettings.TickValue);
                }
            }
        }

        private float GetTime()
        {
            return Time.time;
        }
    }
}