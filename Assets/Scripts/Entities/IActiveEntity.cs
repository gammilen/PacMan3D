using UnityEngine;

namespace PacMan
{
    public interface IActiveEntity
    {
        Vector2Int Position { get; }
    }
}