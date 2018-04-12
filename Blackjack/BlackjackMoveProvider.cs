using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class BlackjackMoveProvider {

        delegate void MoveFunc();

        private IInputProvider InProvider;

        private IOutputProvider OutProvider;

        private MoveProviderState State;

        private IPlayer currentPlayer;

        IDeck Deck;

        Dictionary<string, MoveFunc> MoveRouter;

        public BlackjackMoveProvider(IInputProvider ip, IOutputProvider op, IDeck deck)
        {
            InProvider = ip;
            OutProvider = op;
            State = MoveProviderState.WAITING;
            Deck = deck;

            MoveRouter = new Dictionary<string, MoveFunc>();
        }

        public void SetCurrentPlayer(IPlayer player)
        {
            currentPlayer = player;
        }

        public void InitiatePlayerTurnLoop()
        {
            if (currentPlayer == null)
                return;

            while(State != MoveProviderState.ENDING_TURN)
            {
                
            }
        }

        void PrintMove()
        {
            Console.WriteLine("\nSelect from the following options\n");
            foreach (var move in MoveRouter)
                Console.WriteLine(move.Key);
        }

        void DrawAnotherCard()
        {
            var card = Deck.Draw();
            currentPlayer.Hand.AddCard(card);
        }

        void PlayerStand()
        {
            State = MoveProviderState.ENDING_TURN;
        }

        string GetPlayerInput()
        {
            Console.WriteLine("Enter your move choice");
            string input = InProvider.Read();
        }

  
    }   
}
