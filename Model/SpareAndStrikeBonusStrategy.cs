using System;
using System.Collections.Generic;

namespace BowlingAlleyRepo.Model
{
    public class SpareAndStrikeBonusStrategy : IBonusStrategy
    {

        #region Properties

        private static int SpareBonus => 5;

        private static int StrikeBonus => 10;

        private static int FinalSetIndex => 9;

        private static readonly Random random = new Random();
        
        private static int MaxExtraRollsAllowed => 3;

        private static int MaxPins => 10;

        #endregion

        #region Methods

        public int GetBonusScore(List<int> rolls, int currentSet)
        {
            var bonus = 0;
            if(rolls[0] == 10 || rolls[1] == 10)
            {
                bonus = bonus + StrikeBonus; 
            }
            else if(rolls[0] + rolls[1] == 10)
            {
                bonus = bonus + SpareBonus;
            }

            if(currentSet == FinalSetIndex)
            {
                UpdateScoreFromExtraRolls(ref bonus);
            }

            return bonus;
        }

        private static void UpdateScoreFromExtraRolls(ref int bonus)        
        {
            int extraRollsGranted = random.Next(1, MaxExtraRollsAllowed);
            // Assumption In each extra roll, all 10 balls are reloaded. Player gets one chance to knock as many balls as possible in each roll.
            for(int roll = 0; roll<extraRollsGranted; roll++)
            {
                bonus = bonus + random.Next(1, MaxPins);
            }
        }

        #endregion
    }
}