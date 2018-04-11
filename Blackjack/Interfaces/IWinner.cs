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
        /// <param name="hand1">The Dealer hand</param>
        /// <param name="hand2">The Player hand</param>
        /// <returns></returns>
        bool IsWin(IHand hand1, IHand hand2);
    }
}
