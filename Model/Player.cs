// The model class of each Player.
// Creating Dummy ID. Can be changed in future to take more information from client about player profiles.

namespace BowlingAlleyRepo.Model
{
    public class Player
    {
        #region Fields

        private int playerID;

        private int score;

        private static int idGenerator = 1;

        #endregion

        #region Constructors

        public Player()
        {
            this.score = 0;
            this.playerID = idGenerator++;
        }

        #endregion

        #region Properties

        public int Score => this.score;

        public int ID => this.playerID;

        #endregion


        #region Methods

        public void UpdateScore(int val)
        {
            this.score += val;
        }

        #endregion
    }
}