using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {
    public class Card : ICard {
        public CardSuit Suit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CardValue Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsHidden { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns the corresponding int value of a card's Value enum
        /// </summary>
        /// <returns>Card's blackjack value as an int</returns>
        public int GetIntValue() {
            return (int) Value;
        }
    }
}
