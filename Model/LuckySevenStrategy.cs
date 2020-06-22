using System;
using System.Collections.Generic;

namespace BowlingAlleyRepo.Model
{
    public class LuckySevenStrategy : IBonusStrategy
    {

        #region Properties

        private static int LuckySevenBonus => 7;

        #endregion

        #region Methods

        public int GetBonusScore(List<int> rolls, int currentSet)
        {
            var bonus = 0;
            if(rolls[0] + rolls[1] == 7)
            {
                bonus = bonus + LuckySevenBonus; 
            }

            return bonus;
        }

        #endregion
    }
}