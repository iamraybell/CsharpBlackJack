using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;


namespace Blackjack
{
    public class PlayerManager
    {
        public IPlayer Dealer { get; private set; }


        public List<IPlayer> Players { get; private set; }

        public int CurrentPlayerIndex { get; private set; }

        IDeck Deck;

        public PlayerManager(IPlayer dealer, List<IPlayer> players, IDeck deck)
        {
            Dealer = dealer;
            Players = players;
            CurrentPlayerIndex = 0;
            Deck = deck;
        }

        /// <summary>
        /// Uses the CurrentPlayerIndex to retrieve the current player
        /// </summary>
        /// <returns>current player</returns>
        public IPlayer GetCurrentPlayer()
        {
            if (Players.Count() == 0)
                throw new IndexOutOfRangeException();

            IPlayer currentPlayer = Players[CurrentPlayerIndex];
            return currentPlayer;
        }

        /// <summary>
        /// Increments the current player index until it reaches the end of the list. 
        /// Restarts the index at 0
        /// </summary>
        public void ChangePlayer()
        {
            CurrentPlayerIndex++;
            if(CurrentPlayerIndex >= Players.Count())
            {
                CurrentPlayerIndex = 0;
            }
        }

        /// <summary>
        /// Function that adds a single card to the currentPlayer
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToPlayerCurrentPlayer()
        {
            var card = Deck.Draw();

            IPlayer currentPlayer = GetCurrentPlayer();
            currentPlayer.Hand.AddCard(card);
        }

        public void AddCardToPlayerPlayer(IPlayer player)
        {
            var card = Deck.Draw();

            player.Hand.AddCard(card);
        }


        /// <summary>
        /// Static method that generates and n number of players.
        /// If no argument is provided, the overload defaults to 1 plaayer :D
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <returns>List of instances of Human Player concrete class</returns>
        public static List<IPlayer> InitiatePlayer(int numberOfPlayers)
        {
            List<IPlayer> listOfPlayers = new List<IPlayer>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var generatedPlayer = new HumanPlayer();
                listOfPlayers.Add(generatedPlayer);
            }
            return listOfPlayers;
        }


        public static List<IPlayer> InitiatePlayer()
        {
            return InitiatePlayer(1);
        }


       
    }
}
