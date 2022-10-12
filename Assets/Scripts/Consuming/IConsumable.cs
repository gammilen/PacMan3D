namespace PacMan
{
    public interface IConsumable
    {
        bool CanBeConsumed { get; }
        void BeConsumed();
    }
}