using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    public class LevelField
    {
        public readonly int Width;
        public readonly int Height;
        public readonly IList<Vector2Int> AvailablePosition;

        public LevelField(int width, int height, IList<Vector2Int> availablePositions)
        {
            Width = width;
            Height = height;
            var positions = new List<Vector2Int>();
            foreach (var pos in availablePositions)
            {
                if (pos.x >= 0 && pos.x < Width && pos.y >= 0 && pos.y < Height)
                {
                    positions.Add(pos);
                }
            }
            AvailablePosition = positions;
        }

        public bool IsAvailable(Vector2Int position)
        {
            return AvailablePosition.Contains(position);
        }
    }
}