using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    /// <summary>
    /// IWinner, represents something that checks for a win condition
    /// </summary>
    public interface IWinner
    {
        /// <summary>
        /// Check if the hand total equals a win condition
        /// </summary>
        /// <param name="deck">The deck</param>
        /// <param name="hand">The hand</param>
        /// <returns></returns>
        bool IsWin(IDeck deck, IHand hand);
    }
}
