namespace PacMan
{
    public interface IConsumableConsumer : IConsumable
    {
        bool CanConsume(IConsumable consumable);
        void Consume(IConsumable consumable);
    }
}