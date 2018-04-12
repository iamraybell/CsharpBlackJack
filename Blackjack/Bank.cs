using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class Bank {
        private const int BLACKJACK_STARTING_AMOUNT = 2000;

        public int Balance { get; set; }

        public Bank() {
            Balance = BLACKJACK_STARTING_AMOUNT;
        }

        public Bank(int balance) {
            Balance = balance;
        }

        /// <summary>
        /// Withdraws amount from bank
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Withdraw(int amount) {
            if (Balance < amount) {
                return false;
            }

            Balance -= amount;
            return true;
        }

        /// <summary>
        /// Deposits money in the bank
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(int amount) {
            Balance += amount;
        }
    }
}
