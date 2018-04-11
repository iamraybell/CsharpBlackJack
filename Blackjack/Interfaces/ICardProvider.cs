using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack.Interfaces
{
    public interface ICardProvider
    {
        /// <summary>
        /// This will provide a collection  of cards and return them to caller.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICard> GetCards();
        /// <summary>
        /// Function takes in a suit and value and returns a value for a particular game.
        /// </summary>
        /// <returns></returns>
        int GetValue(CardName name);

    }
}
