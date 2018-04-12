using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    /// <summary>
    /// The Message Provider interface, represents a message provider abstraction
    /// </summary>
    public interface IMessageProvider
    {
        /// <summary>
        /// The welcome message
        /// </summary>
        string Welcome { get; set; }

        /// <summary>
        /// The rules of the game
        /// </summary>
        string Rules { get; set; }

        /// <summary>
        /// Print a welcome message
        /// <param name="welcome">The welcome message to be printed</param>
        /// </summary>
        void printWelcome();

        /// <summary>
        /// Print the rules of the game
        /// <param name="rules">The rules to be printed</param>
        /// </summary>
        void printRules();
    }
}
