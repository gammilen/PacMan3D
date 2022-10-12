using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace PacMan
{
    public class Movement : IMovement
    {
        private readonly LevelField _levelField;
        public Vector2Int CurrentPosition { get; private set; }
        public Vector2Int? TargetPosition { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public Movement(LevelField levelField, Vector2Int defaultPos)
        {
            _levelField = levelField;
            CurrentPosition = defaultPos;
        }

        public void MoveToTarget()
        {
            var lastPos = CurrentPosition;
            if (TargetPosition.HasValue)
            {
                CurrentPosition = Pathfinding.GetNextMove(CurrentPosition, CurrentDirection.ToVector(),
                    TargetPosition.Value, GetAvailableDirections());
            }
            else
            {
                CurrentPosition = Pathfinding.GetNextMove(CurrentPosition, CurrentDirection.ToVector(), GetAvailableDirections());
            }
            if (CurrentPosition != lastPos)
            {
                CurrentDirection = (CurrentPosition - lastPos).ToDirection();
            }
        }

        public bool TrySetDirection(Direction direction)
        {
            var newPos = CurrentPosition + direction.ToVector();
            if (_levelField.IsAvailable(newPos))
            {
                CurrentDirection = direction;
                return true;
            }
            return false;
        }

        public bool TrySetDirection(Vector2Int nextPos)
        {
            if (_levelField.IsAvailable(nextPos) && (nextPos - CurrentPosition).sqrMagnitude == 1)
            {
                CurrentDirection = (nextPos - CurrentPosition).ToDirection();
                return true;
            }
            return false;
        }

        public void SetTarget(Vector2Int? pos)
        {
            TargetPosition = pos;
        }

        public void RandomizeDirection()
        {
            var directions = GetAvailableDirections();
            if (directions.Count > 1)
            {
                directions.Remove(CurrentDirection.GetOpposite().ToVector());
            }
            CurrentDirection = directions[new Random().Next(0, directions.Count)].ToDirection();
        }

        private IList<Vector2Int> GetAvailableDirections() // TODO: rewrite
        {
            var positions = new List<Vector2Int>();
            Vector2Int dir;
            dir = Direction.Up.ToVector();
            TryAddDir();
            dir = Direction.Left.ToVector();
            TryAddDir();
            dir = Direction.Down.ToVector();
            TryAddDir();
            dir = Direction.Right.ToVector();
            TryAddDir();
            return positions;

            void TryAddDir()
            {
                if (_levelField.AvailablePosition.Contains(CurrentPosition + dir))
                {
                    positions.Add(dir);
                }
            }
        }
    }
}