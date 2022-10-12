namespace PacMan
{
    public interface IEnemyAgent : IMovingAgent
    {
        LevelEnemy LevelEnemyData { get; }
        IMovingAgent Target { get; }
    }
}