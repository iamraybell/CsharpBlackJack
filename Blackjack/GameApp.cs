using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class GameApp {

        /// <summary>
        /// Stores the Win State for the human player
        /// </summary>
        public WinState WinState { get; private set; }

        private IPlayer curPlayer;

        private IInputProvider inputProvider { get; set; }
        private IOutputProvider outputProvider { get; set; }
        private IDeck deck { get; set; }
        private List<IPlayer> players { get; set; }
        private IPlayer dealer { get; set; }
        private IPlayer currentPlayer { get; set; }
        public GameState GameState { get; private set; }
        private int PlayerBet { get; set; }

        private IMessageProvider messageProvider;

        const int boardTop = 5;


        public GameApp(IInputProvider inputProvider, IOutputProvider outputProvider, IMessageProvider mp,  IDeck deck) {
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;
            this.deck = deck;
            players = new List<IPlayer>();
            GameState = GameState.RUNNING;
            this.messageProvider = mp;

            Welcome();
        }
        /// <summary>
        /// BlackjackWinChecker, checks for the win condition
        /// </summary>
   




        /// <summary>
        /// Check if the hand total equals a win condition
        /// </summary>
        /// <param name="hand1">The Dealer hand</param>
        /// <param name="hand2">The HumanPlayer hand</param>
        /// <returns></returns>
        public WinState IsWin(IHand hand1, IHand hand2)
        {
            //Compare the total values for win,draw or lose condition
            if (hand2.CompareTo(hand1) > 0)
                WinState = WinState.win;
            else if (hand2.CompareTo(hand1) == 0)
                WinState = WinState.draw;
            else
                WinState = WinState.lose;

            return WinState;
        }

        /// <summary>
        /// takes an IHand method and calls the GetTotalValue method
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>a boolean defining if the value is greater than 21</returns>
        public bool IsTwentyOne(IHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException();

            int handTotal = hand.GetTotalValue(hand.Cards);
            return handTotal == 21;

        }
        

        private void Welcome() {
            outputProvider.WriteLine(MessageProvider.M_WelcomeMessage);

            //audio?
            MyAudioPlayer.playWelcome();
        }

        public void StartGame() {
            // Setup Phase
            Setup();

            // Secondary Setup

            // Game Loop
            while (GameState != GameState.QUITGAME) {

                SetupRound();


                foreach (IPlayer player in players) {
                    currentPlayer = player;
                    PerformSingleTurn(currentPlayer);
                }

                currentPlayer = dealer;
                PerformSingleTurn(currentPlayer);

                EndRoundPhase();
            }

            // Closing phase
        }

        public void GetPlayerBet(IPlayer cPlayer) {        
            outputProvider.WriteLine("\nHow much will you bet? (Invalid entries will be counted as $0. You can play for fun)");
            PlayerBet = cPlayer.GetBet(inputProvider);
        }

        public void EndRoundPhase() {
            WinState ws = IsWin(dealer.Hand, players[0].Hand);
            dealer.Hand.Cards.ForEach(x => x.IsHidden = false);

            Console.SetCursorPosition(0, boardTop);
            PrintEndTableState();
            outputProvider.WriteLine();

            Console.SetCursorPosition(0, boardTop + promptLine + 3);

            switch (ws) {
                case WinState.win:
                    PlayerWon();
                    break;
                case WinState.lose:
                    PlayerLost();
                    break;
                case WinState.draw:
                    PlayerDraw();
                    break;
            }

            dealer.ClearHand();
            players.ForEach(x => x.ClearHand());

            Console.ReadKey();
        }

        private void PlayerWon() {
            players[0].bank.Deposit((int) (PlayerBet * 1.5));
            outputProvider.WriteLine(messageProvider.M_PlayerWon(players[0].Name));
        }

        private void PlayerLost() {
            outputProvider.WriteLine(messageProvider.M_PlayerLost());
        }

        private void PlayerDraw() {
            players[0].bank.Deposit(PlayerBet);
            outputProvider.WriteLine(messageProvider.M_PlayerDraw());

        }

        int promptLine = 12;

        public void PerformSingleTurn(IPlayer cPlayer) {
            PlayerAction pa = PlayerAction.Stand;


            Console.SetCursorPosition(0, boardTop);
            PrintTableState();


            if (cPlayer.type == PlayerType.Human) {
                Console.SetCursorPosition(0, boardTop + promptLine);
                GetPlayerBet(cPlayer);
            }

            do {
                Console.SetCursorPosition(0, boardTop - 2);
                outputProvider.WriteLine(players[0].Name + "'s bank: \t\t\t\t\t\t\t\t.");

                Console.SetCursorPosition(15, 3);
                outputProvider.WriteLine(players[0].bank.Balance.ToString());

                Console.SetCursorPosition(0, boardTop);
                PrintTableState();
                if (cPlayer.StillInPlay) {
                    Console.SetCursorPosition(0, boardTop + promptLine + 1);
                    if (cPlayer.type == PlayerType.Human) {
                        outputProvider.WriteLine(cPlayer.Name + MessageProvider.M_PlayerActionPrompt);
                    } else {
                        outputProvider.WriteLine("--------------------------------------------------------------------------------------------------------------------------\t\t\t\t\t");
                    }
                    outputProvider.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t.");

                    Console.SetCursorPosition(0, boardTop + promptLine + 2);

                    pa = cPlayer.GetAction();
                    DoAction(cPlayer, pa);
                } else {
                    pa = PlayerAction.Stand;
                }
                
            } while (pa == PlayerAction.Hit);

        }

        public void DoAction(IPlayer cPlayer, PlayerAction pa) {
            
            switch (pa) {
                case PlayerAction.DealerMove:
                    cPlayer.InvokeSpecialAction(deck);
                    break;
                case PlayerAction.Hit:
                    ICard c = deck.Draw();
                    c.IsHidden = false;
                    cPlayer.AddCard(c);
                    break;
                case PlayerAction.Stand:
                    break;
                case PlayerAction.Quit:
                    QuitApplication();
                    break;

            }
        }

        private void QuitApplication() {
            MyAudioPlayer.playSeeYou();
            outputProvider.Clear();

            outputProvider.Write(MessageProvider.M_QuitMessage);
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void PrintEndTableState() {
            outputProvider.WriteLine(dealer.Name + " - " + dealer.Hand.GetTotalValue(dealer.Hand.Cards));
            PrintEmptyCards(dealer.Hand.Cards, boardTop + 1);

            foreach (IPlayer p in players) {

                Console.SetCursorPosition(0, boardTop + 6);
                outputProvider.WriteLine(p.Name + " - " + p.Hand.GetTotalValue(p.Hand.Cards));
                PrintEmptyCards(p.Hand.Cards, boardTop + 7);
            }
        }

        public void PrintTableState() {
            outputProvider.WriteLine(dealer.Name);
            PrintEmptyCards(dealer.Hand.Cards, boardTop + 1);
            
            foreach (IPlayer p in players) {

                Console.SetCursorPosition(0, boardTop + 6);
                outputProvider.WriteLine(p.Name + " - " + p.Hand.GetTotalValue(p.Hand.Cards));
                PrintEmptyCards(p.Hand.Cards, boardTop + 7);
            }
        }

        private void PrintEmptyCards(List<ICard> cs, int top) {
            StringBuilder sb = new StringBuilder("");

            string[] arr = new string[] { "┌─────┐", "|     |", "|     |", "|     |", "└─────┘" };


            foreach (string str in arr) {
                for (int i = 0; i < cs.Count; i++) {
                    sb.Append(str + " ");

                }
                sb.Append("\t\t\t\t\t\t\t\t\t\t\t\n");
            }

            Console.SetCursorPosition(0, top);
            outputProvider.WriteLine(sb.ToString());

            int cardPrintWidth = 8;

            for (int i = 0; i < cs.Count; i++) {
                Console.SetCursorPosition((cardPrintWidth * i) + 2, top + 1);
                outputProvider.Write(cs[i].ToString());
            }
        }

        private void SetupRound() {
            PlayerBet = 0;
            outputProvider.Clear();
            outputProvider.WriteLine(MessageProvider.M_RulesMessage);
            //Console.SetCursorPosition(0, boardTop - 2);
            //outputProvider.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.SetCursorPosition(0, boardTop - 2);
            outputProvider.WriteLine(players[0].Name + "'s bank: \t\t\t\t\t\t\t\t.");

            Console.SetCursorPosition(15, 3);
            outputProvider.WriteLine(players[0].bank.Balance.ToString());

            deck.Shuffle();

            for (int i = 0; i < 2; i++) {
                ICard card = deck.Draw();

                if (i == 1) {
                    card.IsHidden = false;
                }

                dealer.AddCard(card);
                foreach (IPlayer player in players) {
                    player.StillInPlay = true;
                    card = deck.Draw();
                    card.IsHidden = false;
                    player.AddCard(card);
                }
            }
        }

        private void RunRound() {

        }

        private void Setup() {
            GetCreatePlayers();

            dealer = new ComputerDealer();
        }

        private void GetCreatePlayers() {

            string playerName = string.Empty;

            while (string.IsNullOrWhiteSpace(playerName)) {
                outputProvider.WriteLine(MessageProvider.M_PromptPlayerName);
                playerName = inputProvider.Read();

            } ;
            players.Add(new HumanPlayer(new BlackjackMoveProvider(inputProvider), playerName));
        }
    }
}
