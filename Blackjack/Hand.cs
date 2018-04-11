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

        private const int MAX_VALUE = 21;
        public List<ICard> Cards { get; set; }

        public Hand() {
            Cards = new List<ICard>();
        }

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

            foreach (ICard card in hand) {
                total += card.Value;
            }

            while (total > MAX_VALUE && aceCount > 0) {
                total -= 10;
                aceCount--;
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

            if (myHand > MAX_VALUE && otherHand > MAX_VALUE)
                return 0;

            if (myHand > MAX_VALUE)
                return -1;

            if (otherHand > MAX_VALUE)
                return 1;

            return myHand - otherHand;
        }
    }
}
