namespace PacMan
{


    public class ScoreConsuming<T> : IConsuming<T>
        where T : IWithScore
    {
        private readonly Score _score;
        public ScoreConsuming(Score score)
        {
            _score = score;
        }

        public virtual void Consume(T withScore)
        {
            _score.AddScore(withScore.Score);
        }
    }

}