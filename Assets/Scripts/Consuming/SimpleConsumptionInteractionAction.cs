namespace PacMan
{
    public class SimpleConsumptionInteractionAction : IInteractionAction
    {
        public IConsumable _consumable;
        public IConsumableConsumer _consumer;

        public SimpleConsumptionInteractionAction(IConsumable consumable, IConsumableConsumer consumer)
        {
            _consumable = consumable;
            _consumer = consumer;
        }

        public void Act()
        {
            if (_consumable.CanBeConsumed && _consumer.CanConsume(_consumable))
            {
                _consumer.Consume(_consumable);
                _consumable.BeConsumed();
            }
        }
    }
}