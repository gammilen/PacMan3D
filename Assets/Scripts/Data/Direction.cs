using UnityEngine;

public enum Direction
{
    Up,
    Left,
    Down,
    Right
}

public static class DirectionsExtensions
{
    public static Direction GetOpposite(this Direction direction)
    {
        return direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new System.ArgumentException("Unknown direction type " + direction)
        };
    }

    public static Vector2Int ToVector(this Direction direction)
    {
        return direction switch
        {
            Direction.Up => Vector2Int.up,
            Direction.Down => Vector2Int.down,
            Direction.Left => Vector2Int.left,
            Direction.Right => Vector2Int.right,
            _ => throw new System.ArgumentException("Unknown direction type " + direction)
        };
    }

    public static Direction ToDirection(this Vector2Int vector)
    {
        if (vector == Vector2Int.up)
        {
            return Direction.Up;
        }
        if (vector == Vector2Int.down)
        {
            return Direction.Down;
        }
        if (vector == Vector2Int.left)
        {
            return Direction.Left;
        }
        if (vector == Vector2Int.right)
        {
            return Direction.Right;
        }
        throw new System.ArgumentException("Unknown vector direction " + vector);
    }
}