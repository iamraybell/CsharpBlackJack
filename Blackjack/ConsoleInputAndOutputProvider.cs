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
        public void Freeze()
        {
            Console.Read();
        }

        /// <summary>
        /// Clear the output
        /// </summary>
        public void Clear()
        {
            // This function should clear the output
            Console.Clear();
        }

        public void SetCursorPosition(int v, int x)
        {
            Console.SetCursorPosition(v, x);
        }
        public void PrintEmptyCards(List<ICard> cs, int top)
        {
            StringBuilder sb = new StringBuilder("");

            string[] arr = new string[] { "┌─────┐", "|     |", "|     |", "|     |", "└─────┘" };


            foreach (string str in arr)
            {
                for (int i = 0; i < cs.Count; i++)
                {
                    sb.Append(str + " ");

                }
                sb.Append("\t\t\t\t\t\t\t\t\t\t\t\n");
            }

           SetCursorPosition(0, top);
           WriteLine(sb.ToString());

            int cardPrintWidth = 8;

            for (int i = 0; i < cs.Count; i++)
            {
                SetCursorPosition((cardPrintWidth * i) + 2, top + 1);
                Write(cs[i].ToString());
            }
        }
    }
}
