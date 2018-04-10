using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {
    public class Card : ICard {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
        public bool IsHidden { get; set; }

        /// <summary>
        /// Returns the corresponding int value of a card's Value enum
        /// </summary>
        /// <returns>Card's blackjack value as an int</returns>
        public int GetIntValue() {
            return (int) Value;
        }

        public override string ToString() {
            if (IsHidden)
                return "[*]";

            //return "[" + 
            return base.ToString();
        }
    }
}
