// The Top Level Model Class representing the entire model of the bowling alley.

using System.Collections.Generic;

namespace BowlingAlleyRepo.Model
{
    public class Alley
    {
        #region Fields

        private List<Lane> lanes;
        
        #endregion

        #region Constructors

        public Alley(int numberOfLanes)
        {
            this.lanes = new List<Lane>();
            for(int i =0; i<numberOfLanes; i++)
            {
                this.lanes.Add(new Lane());
            }
        }

        public void FindEmptyLaneAndAssignGame(int numberOfPlayers, IBonusStrategy bonusStrategy)
        {
            foreach(var lane in this.lanes)
            {
                if(lane.Free == true)
                {
                    lane.AssignGame(numberOfPlayers, bonusStrategy);
                }
            }
        }

        public void StartGamesInAllOccupiedLanes()
        {
            foreach(var lane in this.lanes)
            {
                if(lane.Free != true)
                {
                    lane.StartGame();
                }
            }
        }

        #endregion
    }
}