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
        CardSuit Suit { get; set; }
        CardValue Value { get; set; }
        bool IsHidden { get; set; }

        int GetIntValue();
    }
}
