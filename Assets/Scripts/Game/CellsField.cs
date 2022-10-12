using System.Collections.Generic;
using UnityEngine;
using PacMan;

namespace Game
{
    public class CellsField : MonoBehaviour
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] public float _cellSize;
        private Dictionary<Vector2Int, Vector3> _positions;

        private void Awake()
        {
            _positions = new Dictionary<Vector2Int, Vector3>();
            var fromPos = transform.position;
            fromPos.x += 0.5f *_cellSize;
            fromPos.z += 0.5f * _cellSize;
            for (int i = 0; i < _level.Level.LevelSize.x; i++)
            {
                for (int j = 0; j < _level.Level.LevelSize.y; j++)
                {
                    _positions.Add(new Vector2Int(i, j), fromPos + new Vector3(i * _cellSize, 0, j * _cellSize));
                }
            }
        }

        public Vector3 GetBlockPosition(Vector2Int cellPosition)
        {
            if (_positions.ContainsKey(cellPosition))
            {
                return _positions[cellPosition];
            }
            return new Vector3(transform.position.x + (cellPosition.x + 0.5f) * _cellSize, 
                transform.position.y + 0.01f, transform.position.z + (cellPosition.y + 0.5f) * _cellSize);
        }
        public Vector3 GetAgentPosition(Vector2Int cellPosition)
        {
            return GetBlockPosition(cellPosition);
        }

    }
}