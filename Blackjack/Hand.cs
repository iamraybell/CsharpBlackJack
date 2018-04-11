using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {

    /// <summary>
    /// Represents a player blackjack hand
    /// </summary>
    public class Hand : IHand {
        public List<ICard> Cards { get; set; }

        /// <summary>
        /// Add the passed in ICard to the hand
        /// </summary>
        /// <param name="card">ICard to add to the hand</param>
        public void AddCard(ICard card) {
            Cards.Add(card);
        }

        /// <summary>
        /// Returns the optimal value for the blackjack hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>Blackjack hand value</returns>
        public int GetTotalValue(List<ICard> hand) {
            int total = 0;
            int aceCount = hand.Where(x => x.Name == CardName.Ace).Count();
            //Int aceCount = 0;

            foreach (ICard card in hand) {
                total += card.GetIntValue();
                /*
                 * Can use a ternary to avoid using a linq statement
                 * 
                 * aceCount += hand.Name == CardName.Ace ? 1 : 0;
                 * 
                 * :D
                 * */
            }

            while (total > 21 && aceCount > 0) {
                total -= 10;
            }

            return total;
        }

        /// <summary>
        /// Compares this 'hand' to another. Returns a negative number if less than,
        /// 0 if equal, and a positive number if greater than
        /// </summary>
        /// <param name="other">The other blackjack hand to compare</param>
        /// <returns>negative, 0, or positive number</returns>
        public int CompareTo(IHand other) {
            int myHand = GetTotalValue(Cards);
            int otherHand = GetTotalValue(other.Cards);

            return myHand - otherHand;
        }
    }
}
