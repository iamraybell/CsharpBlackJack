using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class BlackjackMoveProvider : IMoveProvider
    {

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
            MoveRouter.Add("hit", DrawAnotherCard);
            MoveRouter.Add("stand", PlayerStand);
        }

        public void SetCurrentPlayer(IPlayer player)
        {
            currentPlayer = player;
        }

        /// <summary>
        /// Initiates a loop that keeps prompting a player unitl they type stand
        /// </summary>
        public void InitiateLoop()
        {
            if (currentPlayer == null || !currentPlayer.StillInPlay)
                return;

            while(State != MoveProviderState.ENDING_TURN)
            {
                ProcessTurn();
            }
        }

        void ProcessTurn()
        {
            try
            {
                string input = GetPlayerInput();
                ValidatePlayerInput(input);
                InitiateMoveRoute(input);
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("Entry was invalid. Please Trye again");
            }
        }

        void PrintMove()
        {
            Console.WriteLine("\nSelect from the following options\n");
            foreach (var move in MoveRouter)
                Console.WriteLine(move.Key.ToUpper());
        }

        /// <summary>
        /// Hits the deck to draw another card
        /// </summary>
        void DrawAnotherCard()
        {
            var card = Deck.Draw();
            currentPlayer.Hand.AddCard(card);
        }

        /// <summary>
        /// Changes the state of the players turn to end the loop
        /// </summary>
        void PlayerStand()
        {
            State = MoveProviderState.ENDING_TURN;
        }

        /// <summary>
        /// Prompts the player for input
        /// </summary>
        /// <returns></returns>
        string GetPlayerInput()
        {
            PrintMove();
            Console.WriteLine("\nEnter your move choice\n");
            string input = InProvider.Read();

            return input;
        }

        /// <summary>
        /// Ensures the player entry is a possible move
        /// </summary>
        /// <param name="input"></param>
        void ValidatePlayerInput(string input)
        {
            bool containsEntry = MoveRouter.ContainsKey(input.ToLower());

            if (!containsEntry)
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Access the stored funciton in the move router and calls the operation
        /// </summary>
        /// <param name="input"></param>
        void InitiateMoveRoute(string input)
        {
            MoveFunc operation = MoveRouter[input];
            operation();
        }

  
    }   
}
