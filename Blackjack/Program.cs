using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {

            GameApp agm = new GameApp(new ConsoleInputAndOutputProvider(), new ConsoleInputAndOutputProvider(), new MessageProvider(), new Deck());
            agm.StartGame();
        }
    }
}
