using System;
using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{

    [CreateAssetMenu(fileName ="Pellets", menuName ="Services/Pellets Registry")]
    public class PelletsRegistry : ScriptableObject, IEntitiesSource
    {
        [SerializeField] private CurrentLevel _level;
        [SerializeField] private OnLevelEntities _onLevelEntities;
        [SerializeField] private EventChannel _noPelletsChannel;

        [SerializeField] private Score _score;
        [SerializeField] private EnemiesFright _fright;
        
        private List<IActiveEntity> _pellets = new List<IActiveEntity>();

        public event Action<IActiveEntity> PelletConsumed;

        private void OnEnable()
        {
            _onLevelEntities.AddEntitiesSource(this);
        }

        IEnumerable<IActiveEntity> IEntitiesSource.InitEntities()
        {
            _pellets.Clear();
            var pelletConsuming = new ScoreConsuming<Pellet>(_score);
            var energizerConsuming = new EnergizerPelletConsuming(_score, _fright);
            foreach (var pos in _level.Level.PelletsPositions)
            {
                if (_level.Level.MovePositions.Contains(pos) &&
                    !_level.Level.EnergizerPelletsPositions.Contains(pos))
                {
                    var pellet = new PelletState<Pellet>(_level.Level.Pellet, pos, pelletConsuming);
                    pellet.Consumed += UnregisterPellet;
                    _pellets.Add(pellet);
                    yield return pellet;
                }
            }
            foreach (var pos in _level.Level.EnergizerPelletsPositions)
            {
                var pellet = new PelletState<EnergizerPellet>(_level.Level.EnergizerPellet, pos, energizerConsuming);
                pellet.Consumed += UnregisterPellet;
                _pellets.Add(pellet);
                yield return pellet;
            }
        }


        public IEnumerable<PelletState<Pellet>> GetPellets()
        {
            foreach (var entity in _pellets)
            {
                if (entity is PelletState<Pellet> pellet)
                {
                    yield return pellet;
                }
            }
        }

        public IEnumerable<PelletState<EnergizerPellet>> GetEnergizerPellets()
        {
            foreach (var entity in _pellets)
            {
                if (entity is PelletState<EnergizerPellet> pellet)
                {
                    yield return pellet;
                }
            }
        }

        private void UnregisterPellet(IActiveEntity pellet)
        {
            _onLevelEntities.UnregisterEntity(pellet);
            _pellets.Remove(pellet);
            PelletConsumed?.Invoke(pellet);
            if (_pellets.Count == 0)
            {
                _noPelletsChannel.Raise();
                
            }
        }
    }
}