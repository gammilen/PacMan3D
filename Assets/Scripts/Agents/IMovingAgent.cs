namespace PacMan
{
    public interface IMovingAgent
    {
        Movement Movement { get; }
        IStepTickValue StepTickValue { get; }
        void Move();
    }
}