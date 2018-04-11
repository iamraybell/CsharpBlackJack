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

        PlayerAction GetAction();

        void Hit();

        void Stand();
    }
}
