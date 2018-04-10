using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {

    /// <summary>
    /// Represents a card for a deck of cards
    /// </summary>
    public class Card : ICard {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
        public bool IsHidden { get; set; }

        public Card(CardSuit suit, CardValue value, bool isHidden = false) {
            Suit = suit;
            Value = value;
            IsHidden = isHidden;
        }

        /// <summary>
        /// Returns the corresponding int value of a card's Value enum
        /// </summary>
        /// <returns>Card's blackjack value as an int</returns>
        public int GetIntValue() {
            return Value.GetIntValue();
        }

        /// <summary>
        /// Returns a string representation of the card, depending on if
        /// the card 'isHidden'.
        /// </summary>
        /// <returns>String representation of card</returns>
        public override string ToString() {
            if (IsHidden)
                return "[*]";

            return "[" + Value.GetString() + "]";
        }
    }
}
