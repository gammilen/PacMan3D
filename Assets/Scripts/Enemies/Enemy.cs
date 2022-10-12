using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="Enemy", menuName ="Entities/Enemy")]
    public class Enemy : ScriptableObject
    {
        [SerializeField] public float Speed; // 1 / ticks needed to move between two neighbour cells
        [SerializeField] public ChaseStrategy ChaseStrategy;
    }
}