namespace PacMan
{
    public interface IConsuming<T>
    {
        void Consume(T consumable);
    }
	
	public interface IConsuming
    {
        void Consume();
    }
}