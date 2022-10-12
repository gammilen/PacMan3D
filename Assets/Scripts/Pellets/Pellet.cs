using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="Pellet", menuName ="Entities/Pellet")]
    public class Pellet : ScriptableObject, IWithScore
    {
        [SerializeField] public int Score; // when eaten

        int IWithScore.Score => Score;
    }
}