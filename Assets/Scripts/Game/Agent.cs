using System.Collections;
using UnityEngine;

namespace Game
{
    public class Agent : MonoBehaviour
    {
        [SerializeField] private TimeSettings _timeSettings;

        private AgentTicker _ticker;
        private CellsField _cellsField;
        private bool _isMoving;
        private float _currentSpeed;
        private Vector3 _currentTarget;
        private Vector3 _currentMove;

        public void Setup(AgentTicker ticker, CellsField cellsField)
        {
            _cellsField = cellsField;
            _ticker = ticker;
            _ticker.TickEvent += UpdateMove;
            _currentTarget = transform.position;
        }

        private void UpdateMove()
        {
            transform.position = _currentTarget;
            _currentTarget = _cellsField.GetAgentPosition(_ticker.Agent.Movement.CurrentPosition);
            _currentMove = _currentTarget - transform.position;
            _currentSpeed = _currentMove.magnitude / (_ticker.GetTicksForStep() * _timeSettings.TickValue);
            _currentMove = _currentMove.normalized;
            _isMoving = _currentSpeed != 0;
        }

        private void Update()
        {
            if (!_isMoving) return;
            var newPos = transform.position;
            newPos += _currentMove * _currentSpeed * Time.deltaTime;
            transform.position = newPos;
        }


    }
}