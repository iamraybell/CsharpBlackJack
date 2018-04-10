using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IPlayer
    {
        String Name { get; set; }
        IHand Hand { get; set; }

        void Hit();

        void Stand();
    }
}
