using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Exceptions;
using Blackjack.Interfaces;

namespace Blackjack {
    public class GameManager
    {
        /// <summary>
        /// 
        /// </summary>
        private IInputProvider iinputProvider;

        private IOutputProvider ioutputProvider;

        private ICard card;

        private IDeck deck;

        private List<IPlayer> players;


        public void AssignInitialCardsToPlayer()
        {
            players[0].Hand.Cards.Add(deck.Draw());
            players[0].Hand.Cards.Add(deck.Draw());
        } 

        public void AssignInitialCardsToDealer()
        {
            players[1].Hand.Cards.Add(deck.Draw());
            players[1].Hand.Cards.Add(deck.Draw());
        }

        /// <summary>
        /// After typing Deal, HumanPlayer is assigned 2 cards which are displayed along with their total on the screen
        /// </summary>
        public void TypeDealAndShowCards()
        {
            ioutputProvider.WriteLine("Type Deal to have cards dealt");
            iinputProvider.Read();

            AssignInitialCardsToPlayer();
            AssignInitialCardsToDealer();

            ioutputProvider.WriteLine($"Dealer: [{players[1].Hand.Cards[0].GetIntValue()}] [{players[1].Hand.Cards[1].GetIntValue()}]");
            ioutputProvider.WriteLine($"{players[0].Name}: [{players[0].Hand.Cards[0].GetIntValue()}] [{players[0].Hand.Cards[1].GetIntValue()}] - {players[0].Hand.GetTotalValue(players[0].Hand.Cards)}");

        }

    }
}
