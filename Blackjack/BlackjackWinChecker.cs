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
        /// <param name="hand1">The Dealer hand</param>
        /// <param name="hand2">The HumanPlayer hand</param>
        /// <returns></returns>
        public bool IsWin(IHand hand1, IHand hand2);


        /// <summary>
        /// takes an IHand method and calls the GetTotalValue method
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>a boolean defining if the value is greater than 21</returns>
        bool IsTwentyOne(IHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException();

            int handTotal = hand.GetTotalValue();
            return hand == 21;
            
        }
    }
}
