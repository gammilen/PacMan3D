using System.Collections;
using UnityEngine;
using PacMan;

namespace Game
{
    public class BlocksSpawner : MonoBehaviour
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private GameObject _blockPrefab;
        [SerializeField] private CellsField _cellsField;
        
        private void Start()
        {
            for (int i = 0; i < _level.Level.LevelSize.x; i++)
            {
                for (int j = 0; j < _level.Level.LevelSize.y; j++)
                {
                    var pos = new Vector2Int(i, j);
                    if (!_level.Level.MovePositions.Contains(pos))
                    {
                        InitBlock(pos);
                    }
                }
            }
            
        }

        private void InitBlock(Vector2Int position)
        {
            var block = Instantiate(_blockPrefab, transform);
            block.transform.position = _cellsField.GetBlockPosition(position);
        }
    }
}