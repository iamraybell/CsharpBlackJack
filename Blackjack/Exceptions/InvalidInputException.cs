using System;

namespace Blackjack.Exceptions {
    /// <summary>
    /// Exception representing an invalid input from the user
    /// </summary>
    public class InvalidInputException : Exception {
        public InvalidInputException() {
        }

        public InvalidInputException(string message)
        : base(message) {
        }

        public InvalidInputException(string message, Exception inner)
        : base(message, inner) {
        }
    }
}
