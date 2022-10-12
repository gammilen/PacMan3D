using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    [System.Serializable]
    public class LevelEnemy : IWithScore
    {
        [field: SerializeField] public Enemy Enemy;
        [field: SerializeField] public Vector2Int DefaultPosition;
        [field: SerializeField] public Vector2Int ScatterPosition;
        [field: SerializeField] public int Score; // when eaten
        [field: SerializeField] public float SpeedMultiplier;

        int IWithScore.Score => Score;
    }

    [CreateAssetMenu(fileName = "Level", menuName = "Entities/Level")]
    public class Level : ScriptableObject
    {
        [SerializeField] private string _movePositionsText;

        [field: SerializeField] public Vector2Int LevelSize { get; private set; }
        [field: SerializeField] public int ScatterTicks { get; private set; }
        [field: SerializeField] public int ChaseTicks { get; private set; }
        [field: SerializeField] public int FrightenedTicks { get; private set; }
        [field: SerializeField] public Vector2Int PlayerPosition { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public int PlayerLives { get; private set; }

        [SerializeField] private List<LevelEnemy> _enemies;
        [SerializeField] private List<Vector2Int> _movePositions;
        [SerializeField] private List<Vector2Int> _energizerPelletsPositions;
        [SerializeField] private List<Vector2Int> _pelletsPositions;
        [field: SerializeField] public Pellet Pellet { get; private set; }
        [field: SerializeField] public EnergizerPellet EnergizerPellet { get; private set; }

        public IList<Vector2Int> PelletsPositions => _pelletsPositions;
        public IList<Vector2Int> EnergizerPelletsPositions => _energizerPelletsPositions;
        public IList<Vector2Int> MovePositions => _movePositions;
        public IList<LevelEnemy> Enemies => _enemies;


        // TODO: add data correction


        public LevelField GetField()
        {
            return new LevelField(LevelSize.x, LevelSize.y, _movePositions);
        }

        [ContextMenu("ParseText")]
        private void ParseMoveText()
        {
            _movePositions.Clear();
            for (int i = 0; i < LevelSize.x; i++)
            {
                for (int j = 0; j < LevelSize.y; j++)
                {
                    var pos = new Vector2Int(i, j);
                    if (_movePositionsText[j * LevelSize.x + i] == '1')
                    {
                        _movePositions.Add(pos);
                    }
                }
            }
        }

    }
}