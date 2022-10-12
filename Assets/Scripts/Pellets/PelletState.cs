using System;
using UnityEngine;

namespace PacMan
{
    public class PelletState<T> : IActiveEntity, IConsumable
        where T: Pellet
    {
        public readonly T Pellet;
        public readonly Vector2Int Position;
        private IConsuming<T> _consuming;
        Vector2Int IActiveEntity.Position => Position;

        bool IConsumable.CanBeConsumed => true;
        public event Action<IActiveEntity> Consumed;

        public PelletState(T pellet, Vector2Int position, IConsuming<T> consuming)
        {
            Pellet = pellet;
            Position = position;
            _consuming = consuming;
        }

        public void BeConsumed()
        {
            _consuming.Consume(Pellet);
            Consumed?.Invoke(this);
        }
    }
}