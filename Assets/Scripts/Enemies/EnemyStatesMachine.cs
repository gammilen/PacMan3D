namespace PacMan
{
    public class EnemyStatesMachine
    {
        public readonly IEnemyState EatenState;
        public readonly IEnemyState ScatterState;
        public readonly IEnemyState ChaseState;
        public readonly IEnemyState FrightenedState;

        public IEnemyState CurrentState { get; private set; }
        public IEnemyState PreviousState { get; private set; }

        public EnemyStatesMachine(IEnemyState eatenState, IEnemyState scatterState, IEnemyState chaseState,
            IEnemyState frightenedState)
        {
            EatenState = eatenState;
            ScatterState = scatterState;
            ChaseState = chaseState;
            FrightenedState = frightenedState;
            ChangeState(ScatterState, false);
        }

        public void Update(float ticks)
        {
            CurrentState.Update(ticks);
            TryUpdateState();
        }

        public void BeFrightened()
        {
            ChangeState(FrightenedState, false);
        }

        public void BeConsumed()
        {
            ChangeState(EatenState, true);
        }

        public void TryUpdateState()
        {
            if (CurrentState.CanMoveToNextState())
            {
                ChangeState(GetNextState(), true);
            }
        }

        private void ChangeState(IEnemyState state, bool withReset)
        {
            if (withReset)
            {
                CurrentState.ResetState();
            }
            PreviousState = CurrentState;
            CurrentState = state;
            CurrentState.Enter();
        }

        private IEnemyState GetNextState()
        {
            if (CurrentState == EatenState)
            {
                return ChaseState;
            }
            if (CurrentState == ScatterState)
            {
                return ChaseState;
            }
            if (CurrentState == ChaseState)
            {
                return ScatterState;
            }
            if (CurrentState == FrightenedState)
            {
                return PreviousState;
            }
            return ScatterState;
        }
    }
}