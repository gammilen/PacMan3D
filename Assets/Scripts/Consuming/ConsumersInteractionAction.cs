namespace PacMan
{
    public class ConsumersInteractionAction : IInteractionAction
    {
        public IConsumableConsumer _firstConsumer;
        public IConsumableConsumer _secondConsumer;

        public ConsumersInteractionAction(IConsumableConsumer firstConsumer, IConsumableConsumer secondConsumer)
        {
            _firstConsumer = firstConsumer;
            _secondConsumer = secondConsumer;
        }

        public void Act()
        {
            if (_firstConsumer.CanConsume(_secondConsumer) && _secondConsumer.CanBeConsumed)
            {
                _firstConsumer.Consume(_secondConsumer);
                _secondConsumer.BeConsumed();
            }
        }
    }
}