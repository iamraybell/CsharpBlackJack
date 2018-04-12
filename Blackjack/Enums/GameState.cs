using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Enums
{
    public enum GameState
    {
        RUNNING,
        DEALING,
        INITIATING_ROUND,
        INITIATING_TURN,
        WIN_CHECKING,
        TERMINATING,
        QUITGAME
    }
}
