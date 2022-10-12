using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    public static class Pathfinding
    {
        public static Vector2Int GetNextMove(Vector2Int fromPos, Vector2Int fromDir, Vector2Int targetPos, IList<Vector2Int> availableDirections)
        {
            if (availableDirections.Count != 1)
            {
                availableDirections.Remove(-fromDir); // restrict reverse move
            }
            var minDist = int.MaxValue;
            Vector2Int direction = new Vector2Int();
            foreach (var dir in availableDirections)
            {
                var nPos = fromPos + dir;
                var distance = (nPos - targetPos).sqrMagnitude;
                if (!(distance <= minDist))
                    continue;

                minDist = distance;
                direction = dir;
            }

            return fromPos + direction;
        }

        public static Vector2Int GetNextMove(Vector2Int fromPos, Vector2Int fromDir, IList<Vector2Int> availableDirections)
        {
            if (availableDirections.Contains(fromDir))
            {
                return fromPos + fromDir;
            }
            return fromPos;
        }
    }
}