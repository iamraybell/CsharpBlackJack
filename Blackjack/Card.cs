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
    public class Card : ICard{
        // TODO: no ICard// leave for now
        // Only get-only properties: public CardSuit Suit {get;}// changed
        // IsHidden is mutable.
        // No value in constructor// changed

        private CardName king;
        private CardSuit hearts;

        public CardSuit Suit { get;}
        public CardName Name { get; }

        public static Card Create(CardName king, CardSuit hearts)
        {
            return new Card(king, hearts);
        }

        public int Value { get; set; }
        public bool IsHidden { get; set;}

        public Card(CardSuit suit, CardName name, int value) {
            Suit = suit;
            Name = name;
            Value = value;
            IsHidden = true;
        }

        public Card(CardName name, CardSuit sute)
            : this(sute, name, CalculateValue(name))
        {
        }

        private static int CalculateValue(CardName name)
        {
            string nameToString = name.GetString();
            int value;
            bool results = int.TryParse(nameToString, out value);

            if (results)
            {
                return value;
            }
            else if (name == CardName.Ace)
            {
                return 11;
            }
            return 10;
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
