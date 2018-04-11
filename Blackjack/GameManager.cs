using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class GameManager {



        /// <summary>
        /// The output provider
        /// </summary>
        private IOutputProvider outputProvider;

        /// <summary>
        /// The input provider
        /// </summary>
        private IInputProvider inputProvider;

        /// <summary>
        /// The list of players, uses IPlayers.
        /// </summary>
        private List<IPlayer> players;

        /// <summary>
        /// Prompts user for name, creates player, and adds player to the list.
        /// </summary>
        private void CreatePlayer()
        {
            //prompt user for name
            outputProvider.WriteLine("Player 1, Enter your name.");

            var inputName = inputProvider.Read();

            var player = new HumanPlayer();

            //if input is null or empty, set to default Player 1
            if (string.IsNullOrEmpty(inputName))
            {
                player.Name = "Player 1";
            }
            else
            {
                player.Name = inputName;
            }

            // add to player list
            players.Add(player);
        }
    }
}
