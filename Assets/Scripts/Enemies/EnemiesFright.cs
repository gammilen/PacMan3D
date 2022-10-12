using UnityEditor;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="EnemiesFright", menuName ="Services/Enemies Fright")]
    public class EnemiesFright : ScriptableObject
    {
        [SerializeField] private EnemiesAgentsRegistry _registry;
        
        public void Fright()
        {
            foreach (var enemy in _registry.Enemies)
            {
                enemy.BeFrightened();
            }
        }
    }
}