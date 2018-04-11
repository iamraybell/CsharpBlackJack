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
    public class BlackjackWinChecker : IWinner
    {
        /// <summary>
        /// Stores the Win State for the human player
        /// </summary>
        public WinState WinState { get; private set; }


        /// <summary>
        /// Check if the hand total equals a win condition
        /// </summary>
        /// <param name="hand1">The Dealer hand</param>
        /// <param name="hand2">The HumanPlayer hand</param>
        /// <returns></returns>
        public WinState IsWin(IHand hand1, IHand hand2)
        {
            //Compare the total values for win,draw or lose condition
            if (hand2.CompareTo(hand1) > 0)
                WinState = WinState.win;
            else if (hand2.CompareTo(hand1) == 0)
                WinState = WinState.draw;
            else
                WinState = WinState.lose;

            return WinState;
        }

        /// <summary>
        /// takes an IHand method and calls the GetTotalValue method
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>a boolean defining if the value is greater than 21</returns>
        public bool IsTwentyOne(IHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException();

            int handTotal = hand.GetTotalValue(hand.Cards);
            return handTotal == 21;

        }
    }
}
