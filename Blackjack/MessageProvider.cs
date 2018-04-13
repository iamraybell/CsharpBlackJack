using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class MessageProvider : IMessageProvider
    {
        public static string M_WelcomeMessage = "Welcome to Blackjack!";
        public static string M_RulesMessage = "**\tBlackjack plays 3 to 2.\n\tDealer draws to 16, must stand on 17.  **";
        public static string M_PromptPlayerName = "Please enter a player name: ";
        public static string M_BetPrompt = "Make your best bet! :";
        public static string M_PlayerActionPrompt = " Do you want to 'Hit' or 'Stand'? :\t\t\t\t\t\t\t\t";
        public static string M_BankString = "Bank";
        public static string M_PlayerWon = "!!!!!!!!!!!!!!!!!!!\tYOU WON\t!!!!!!!!!!!!!!!!!!!!!";
        public static string M_PlayerLost = "....................\tyou lost\t....................";
        public static string M_PlayerDraw = "--------------------\tYou Tied\t---------------------";

        /// <summary>
        /// A welcome message
        /// </summary>
        public string Welcome { get; set; }

        /// <summary>
        /// The rules of the game
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// The one and only constructor
        /// <param name="welcome"> The welcome message</param>
        /// <param name="rules"> The rules of the game</param>
        /// </summary>
        public MessageProvider(string welcome, string rules)
        {
            this.Welcome = welcome;
            this.Rules = rules;
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
        }

        /// <summary>
        /// Prints a welcome message to the console
        /// <param name="welcome"> The welcome message that is printed at the beginning of the game</param>
        /// </summary>
        public void printWelcome(string welcome)
        {
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            //call the console output provider's writeLine method and pass in the welcome; this outputs the rules to the console
            consoleOutputProvider.WriteLine(welcome);
        }

        /// <summary>
        /// Prints a welcome message to the console
        /// </summary>
        public void printWelcome()
        {
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            //call the console output provider's writeLine method and pass in the welcome; this outputs the rules to the console
            consoleOutputProvider.WriteLine(this.Welcome);
        }

        /// <summary>
        /// Prints the rules to the console
        /// <param name="rules"> The rules of the game, to be printed to the console by this method
        /// </summary>
        public void printRules(string rules)
        {
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            //call the console output provider's writeLine method and pass in the rules; this outputs the rules to the console
            consoleOutputProvider.WriteLine(rules);
        }

        /// <summary>
        /// Prints the rules to the console
        /// </summary>
        public void printRules()
        {
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            //call the console output provider's writeLine method and pass in the rules; this outputs the rules to the console
            consoleOutputProvider.WriteLine(this.Rules);
        }
    }
}
