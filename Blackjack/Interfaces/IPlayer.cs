using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack.Interfaces
{
    public interface IPlayer
    {
        String Name { get; set; }
        IHand Hand { get; set; }
        Bank bank { get; set; }
        bool IsHuman { get; set; }

        bool StillInPlay { get; set; }

        PlayerAction GetAction();

        int GetBet(IInputProvider ip);

        void Hit();

        void Stand();

        void InvokeSpecialAction(IDeck deck);

        void AddCard(ICard card);
        void ClearHand();
    }
}
