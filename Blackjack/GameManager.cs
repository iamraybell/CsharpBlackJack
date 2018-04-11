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

        private PlayerManager playerManager;

        private ICard card;

        private IDeck deck;

        private List<IPlayer> players;
        int currentPlayerIndex;

        GameState State;

        IPlayer dealer;



        public GameManager(IDeck deck, IOutputProvider output, IInputProvider input, PlayerManager pm)
        {
            this.deck = deck;

            iinputProvider = input;
            ioutputProvider = output;
            playerManager = pm;

            State = GameState.INITIATING_ROUND;

        }

        /// <summary>
        /// Initiates a reocurring loop unitl the game state is set to TERMINATING
        /// </summary>
        public void InitiateLoop()
        {

            while (State != GameState.TERMINATING)
            {
                InitiateNewRound();
            }
        }

        void InitiateNewRound()
        {
            if(State == GameState.INITIATING_ROUND)
            {
                foreach (var player in players)
                {
                    ResetHand(player);
                }
                State = GameState.INITIATING_TURN;
            }
        }

        void ResetHand(IPlayer player)
        {
            player.Hand = new Hand();
            for(int i = 0; i < 2; i++)
            {
                var card = deck.Draw();
                player.Hand.AddCard(card);
            }
        }


        void InitiatPlayerTurn()
        {
            if(State == GameState.RUNNING)
            {

            }
        }


        void InitiateRoundOfDealing()
        {
            if(State == GameState.DEALING)
            {

            }
        }



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
