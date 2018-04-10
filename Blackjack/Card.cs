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
        public CardName Name { get; set; }
        public int Value { get; set; }
        public bool IsHidden { get; set; }

        public Card(CardSuit suit, CardName name, int value) {
            Suit = suit;
            Name = name;
            Value = value;
            IsHidden = false;
        }

        /// <summary>
        /// Returns the corresponding int value of a card's Value enum
        /// </summary>
        /// <returns>Card's blackjack value as an int</returns>
        public int GetIntValue() {
            return Value;
        }

        /// <summary>
        /// Returns a string representation of the card, depending on if
        /// the card 'isHidden'.
        /// </summary>
        /// <returns>String representation of card</returns>
        public override string ToString() {
            if (IsHidden)
                return "[*]";

            return "[" + Name.GetString() + "]";
        }
    }
}
