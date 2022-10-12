namespace PacMan
{
    public interface IMovementUpdater
    {
        void UpdateTarget(IMovement movement);
    }

    public interface IMovement
    {
        bool TrySetDirection(Direction direction);
    }
}