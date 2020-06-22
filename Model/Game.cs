using System.Collections.Generic;
using System;
using System.Linq;


// The Model class for Game which stores the Game Behavior and the players associated in that game via Commposition.
// Creating Dummy ID. Can be changed in future to take information from client.

namespace BowlingAlleyRepo.Model
{
    public class Game
    {
        #region Fields

        private int gameID;

        private List<Player> players;

        private static int idGenerator = 1;

        private static readonly Random random = new Random();

        #endregion

        #region Properties

        private IBonusStrategy BonusStrategy;

        private int NumberOfSets => 10;

        private int MaxRollInEachSet => 2;

        #endregion

        #region Constructors

        public Game(int numberOfPlayers, IBonusStrategy bonusStrategy)
        {
            this.players = new List<Player>();
            for(int i = 0; i<numberOfPlayers; i++)
            {
                this.players.Add(new Player());
            }

            this.BonusStrategy = bonusStrategy;
            this.gameID = idGenerator++;
        }

        #endregion

        #region Methods

        
        public void PlayGame()
        {
            for(int set =0; set<NumberOfSets; set++)
            {
                foreach(var player in this.players)
                {
                    int currBalls = 10;
                    List<int> rolls = new List<int>();
                    for(int roll = 0; roll<MaxRollInEachSet; roll++)
                    {
                        int generateRandomNumber = random.Next(1, currBalls);
                        player.UpdateScore(generateRandomNumber);
                        rolls.Add(generateRandomNumber);
                        currBalls = currBalls - generateRandomNumber;
                    }

                    player.UpdateScore(BonusStrategy.GetBonusScore(rolls, set));
                }
            }


            this.DisplayResults();
        }

        // This method is invoked once the game is over to get details about how the players performed.

        private void DisplayResults()
        {
            List<Player> rankings = this.players.OrderByDescending(x => x.Score).ToList();

            Console.WriteLine("Game ID " + this.gameID.ToString());
            Console.WriteLine("Number of Players " + rankings.Count.ToString());

            foreach(var rank in rankings)
            {
                Console.WriteLine("Player ID " + rank.ID.ToString() + " : " + "Score " + rank.Score.ToString());
            }
        }

        #endregion
    }   
}