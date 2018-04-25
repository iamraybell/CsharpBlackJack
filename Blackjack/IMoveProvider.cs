using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack.Interfaces {
    public interface IMoveProvider {
        void SetCurrentPlayer(IPlayer Player);

        void InitiateLoop();


        // --------------------------------------
        // ALT INTERFACE
        // --------------------------------------

        PlayerAction GetAction();
    }
}
