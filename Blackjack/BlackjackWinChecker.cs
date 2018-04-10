using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {

    /// <summary>
    /// BlackjackWinChecker, checks for the win condition
    /// </summary>
    public class BlackjackWinChecker : IWinChecker
    {
        /// <summary>
        /// Check if the hand total equals a win condition
        /// </summary>
        /// <param name="deck">The deck</param>
        /// <param name="hand">The hand</param>
        /// <returns></returns>
        public bool IsWin(IDeck deck, IHand hand);
    }
}
