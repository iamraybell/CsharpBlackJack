using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class GameManager {

        /// <summary>
        /// Enumerable data type that holds all instances of IPlayer
        /// </summary>
        public IEnumerable<IPlayer> Players { get; private set; }
        /// <summary>
        /// Enumerator state of the application loop
        /// </summary>
        public GameState State { get; private set; }
        public GameManager(
            IEnumerable<IPlayer> players, 
            GameState initialState)
        {
            Players = players;
            State = initialState;
        }

        public void InitiateGame()
        {
            while(State != GameState.TERMINATING)
            {

            }
        }

        
    }
}
