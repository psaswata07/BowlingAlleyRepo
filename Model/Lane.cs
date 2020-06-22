// The Model Class for Lane. This class encapsulates the Game Model class via Composition.
// Creating Dummy ID. Can be changed in future to take information from client.

namespace BowlingAlleyRepo.Model
{
    public class Lane
    {
        #region Fields

        private static int idGenerator = 1;
        
        #endregion

        #region Properties

        public int LaneId;


        // This property Indicates whether the lane is occupied now or not.
        public bool Free => this.Game == null ? true : false;

        private Game Game;

        #endregion

        #region Constructors

        public Lane()
        {
            this.Game = null;
            this.LaneId = idGenerator++;
        }

        #endregion;

        #region Methods

        public void AssignGame(int numberOfPlayers, IBonusStrategy bonusStrategy)
        {
            if(this.Free == true)
            {
                this.Game = new Game(numberOfPlayers, bonusStrategy);
            }
        }

        public void StartGame()
        {
            this.Game?.PlayGame();

            this.Game = null;
        }

        #endregion
    }
}