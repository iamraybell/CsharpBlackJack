using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {

    /// <summary>
    /// This ConsoleInputProvider class, provides inputs from the Console
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Read a line from the console
        /// </summary>
        /// <returns>A string</returns>
        public string Read()
        {
            // This function should read a line from the console and return it
            var input = Console.ReadLine();
            return input;
        }
    }
}
