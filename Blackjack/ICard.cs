using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack.Interfaces
{
    public interface ICard
    {
        CardSuit Suit { get; }
        CardName Name { get; }
        int Value { get; set; }
        bool IsHidden { get; set; }

        /// <summary>
        /// Returns the corresponding int value of a card's Value enum
        /// </summary>
        /// <returns>Card's value as an int</returns>
        int GetIntValue();
    }
}
