using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {
    /// <summary>
    /// The ConsoleOutputProvider class, provides outputs to the Console
    /// </summary>
    public class ConsoleInputAndOutputProvider : IOutputProvider, IInputProvider
    {
        /// <summary>
        /// Write the specified output to the console
        /// </summary>
        /// <param name="output">The output</param>
        ///

        public string Read()
        {
            // This function should read a line from the console and return it
            var input = Console.ReadLine();
            return input;
        }
        public void Write(string output)
        {
           Console.Write(output);
        }

        /// <summary>
        /// Write the output with a new line
        /// <param name="output"></param>
        /// </summary>
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Write an empty new line
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Clear the output
        /// </summary>
        public void Clear()
        {
            // This function should clear the output
            Console.Clear();
        }
    }
}
