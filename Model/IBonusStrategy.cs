using System.Collections.Generic;

//Created an Interface so that all future bonus offers follows the binding of this contract.
//This allows to easily add new bonus schemes in future without touching the model.

namespace BowlingAlleyRepo.Model
{
    public interface IBonusStrategy
    {
        #region Methods

        int GetBonusScore(List<int> rolls, int currentSet); 

        #endregion       
    }
}