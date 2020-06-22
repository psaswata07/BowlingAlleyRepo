using BowlingAlleyRepo.Model;
using System;
using System.Collections.Generic;

//Driver Class that Simulates the Bowling Alley. Allows Client to Specify the Bonus Strategy, Number of Lanes and the Number of Games to be Simulated.
public static class AlleyManager
{
    #region Properties

    private static int MinNumberOfPlayers => 2;

    private static int MaxNumberOfPlayers => 5;

    private static readonly Random random = new Random();

    private static Alley Alley;

    #endregion;

    #region Methods

    public static  void SimulateBowlingArena(int numberOfLanes, int numberOfGamesToBePlayed, IBonusStrategy bonusStrategy)
    {
        Alley = new Alley(numberOfLanes);

        while(numberOfGamesToBePlayed > 0)
        {
            int numberOfGamesThatCanBeAccomodated = Math.Min(numberOfGamesToBePlayed, numberOfLanes);

            for(int i = 0; i<numberOfGamesThatCanBeAccomodated; i++)
            {
                Alley.FindEmptyLaneAndAssignGame(random.Next(MinNumberOfPlayers, MaxNumberOfPlayers), bonusStrategy);
            }

            Alley.StartGamesInAllOccupiedLanes();

            numberOfGamesToBePlayed = numberOfGamesToBePlayed - numberOfGamesThatCanBeAccomodated;
        }
    }

    #endregion
}