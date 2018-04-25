using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Enums
{
    public enum GameState
    {
        Running,
        Dealing,
        InitiatingRound,
        InitiatingTurn,
        winChecking,
        terminating,
        quitGame
    }
}
