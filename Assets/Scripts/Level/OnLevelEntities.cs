using System;
using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    [CreateAssetMenu(fileName ="OnLevelEntities", menuName ="Services/Level Entities")]
    public class OnLevelEntities : ScriptableObject
    {
        [SerializeField] private CurrentLevel _level;
        private List<IActiveEntity> _entities = new List<IActiveEntity>();
        private List<IEntitiesSource> _entitiesSources = new List<IEntitiesSource>();

        private void OnEnable()
        {
            _level.LevelChanged += Refresh;
        }

        public void AddEntitiesSource(IEntitiesSource source)
        {
            _entitiesSources.Add(source);
        }

        public void UnregisterEntity(IActiveEntity entity)
        {
            if (_entities.Contains(entity))
            {
                _entities.Remove(entity);
            }
        }

        public IEnumerable<IActiveEntity> GetEntities(Vector2Int onPosition)
        {
            foreach (var entity in _entities)
            {
                if (entity.Position == onPosition)
                {
                    yield return entity;
                }
            }
        }

        private void Refresh()
        {
            Debug.Log("refresh on level entities");
            Debug.Log(_entitiesSources.Count);
            _entities.Clear();
            foreach (var source in _entitiesSources)
            {
                _entities.AddRange(source.InitEntities());
            }
        }
    }
}