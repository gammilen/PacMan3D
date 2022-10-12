namespace PacMan
{
    public class EnergizerPelletConsuming : ScoreConsuming<EnergizerPellet>
    {
        private readonly EnemiesFright _fright;
        public EnergizerPelletConsuming(Score score, EnemiesFright fright) : base(score)
        {
            _fright = fright;
        }

        public override void Consume(EnergizerPellet pellet)
        {
            base.Consume(pellet);
            _fright.Fright();
        }
    }
}