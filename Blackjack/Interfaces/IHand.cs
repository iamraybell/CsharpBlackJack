using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IHand
    {
        List<ICard> Cards { get; set; }

        void AddCard(ICard card);

        int GetTotalValue(List<ICard> hand);

        int CompareTo(IHand other);

    }
}
