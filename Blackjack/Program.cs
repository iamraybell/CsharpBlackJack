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
            /* MessageProvider messageProvider = new MessageProvider("Blackjack!", "BlackJack pays 3 to 2. Dealer draws to 16, must stand on 17. Press any key to continue . . .");
             messageProvider.printWelcome();
             messageProvider.printRules();
             Console.ReadLine();
             var testBJCP = new BlackJackCardProvider();
             testBJCP.GetValue(CardName.Eight);*/
            GameApp agm = new GameApp(new ConsoleInputProvider(), new ConsoleOutputProvider(),  new Deck());
            agm.StartGame();
        }
    }
}
