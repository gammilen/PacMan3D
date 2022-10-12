using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace PacMan
{
    

    public class PositionInteractionActionSource
    {
        [SerializeField] private OnLevelEntities _onLevelEntities;

        public PositionInteractionActionSource(OnLevelEntities onLevelEntities)
        {
            _onLevelEntities = onLevelEntities;
        }

        public void Act(IActiveEntity entity)
        {
            foreach (var action in TryGetActions(entity))
            {
                action.Act();
            }
        }

        public List<IInteractionAction> TryGetActions(IActiveEntity entity)
        {
            var entities = _onLevelEntities.GetEntities(entity.Position).ToList();
            var actions = new List<IInteractionAction>();
            if (entities.Count == 1 || !(entity is IConsumableConsumer eConsumer))
            {
                return actions;
            }
            foreach (var e in entities)
            {
                if (!ReferenceEquals(entity, e))
                {
                    if (e is IConsumable consumable)
                    {
                        actions.Add(new SimpleConsumptionInteractionAction(consumable, eConsumer));
                    }
                }
            }
            return actions;   
        }
    }
}
