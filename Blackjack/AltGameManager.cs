using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class AltGameManager {

        private IInputProvider inputProvider { get; set; }
        private IOutputProvider outputProvider { get; set; }
        private IWinner winChecker { get; set; }
        private IDeck deck { get; set; }
        private List<IPlayer> players { get; set; }
        private IPlayer dealer { get; set; }
        private IPlayer currentPlayer { get; set; }
        public GameState GameState { get; private set; }
        private int PlayerBet { get; set; }

        const int boardTop = 5;

        public AltGameManager(IInputProvider inputProvider, IOutputProvider outputProvider, IWinner winChecker, IDeck deck) {
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;
            this.winChecker = winChecker;
            this.deck = deck;
            players = new List<IPlayer>();
            GameState = GameState.RUNNING;

            Welcome();
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
            outputProvider.WriteLine("\nHow much will you bet? (Invalid entries with be counted as $0. You can play for fun)");
            PlayerBet = cPlayer.GetBet(inputProvider);
        }

        public void EndRoundPhase() {
            WinState ws = winChecker.IsWin(dealer.Hand, players[0].Hand);
            dealer.Hand.Cards.ForEach(x => x.IsHidden = false);

            Console.SetCursorPosition(0, boardTop);
            PrintEndTableState();
            outputProvider.WriteLine();

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
            outputProvider.WriteLine(MessageProvider.M_PlayerWon);
        }

        private void PlayerLost() {
            outputProvider.WriteLine(MessageProvider.M_PlayerLost);
            MyAudioPlayer.playHumanPlayerBust();
        }

        private void PlayerDraw() {
            players[0].bank.Deposit(PlayerBet);
            outputProvider.WriteLine(MessageProvider.M_PlayerDraw);

        }

        public void PerformSingleTurn(IPlayer cPlayer) {
            PlayerAction pa = PlayerAction.Stand;


            Console.SetCursorPosition(0, boardTop);
            PrintTableState();


            if (cPlayer.IsHuman) {
                GetPlayerBet(cPlayer);
            }

            do {
                Console.SetCursorPosition(0, boardTop - 2);
                outputProvider.WriteLine(players[0].Name + "'s bank: " + players[0].bank.Balance.ToString());
                Console.SetCursorPosition(0, boardTop);
                PrintTableState();
                if (cPlayer.StillInPlay) {
                    outputProvider.WriteLine("\n" + cPlayer.Name + MessageProvider.M_PlayerActionPrompt);
                    outputProvider.WriteLine("\t\t\t\t\t\t.");
                    Console.SetCursorPosition(0, boardTop + 5);
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

        }

        public void PrintEndTableState() {
            outputProvider.WriteLine(dealer.Name + ": " + dealer.Hand.ToString() + " - " + dealer.Hand.GetTotalValue(dealer.Hand.Cards));

            foreach (IPlayer p in players) {
                outputProvider.WriteLine(p.Name + ": " + p.Hand.ToString() + " - " + p.Hand.GetTotalValue(p.Hand.Cards));
            }
        }

        public void PrintTableState() {
            outputProvider.WriteLine(dealer.Name + ": " + dealer.Hand.ToString());
            
            foreach (IPlayer p in players) {
                outputProvider.WriteLine(p.Name + ": " + p.Hand.ToString() + " - " + p.Hand.GetTotalValue(p.Hand.Cards));
            }
        }

        private void SetupRound() {
            outputProvider.Clear();
            outputProvider.WriteLine(MessageProvider.M_RulesMessage);
            Console.SetCursorPosition(0, boardTop - 2);
            outputProvider.WriteLine(players[0].Name + "'s bank: " + players[0].bank.Balance.ToString());

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
            MyAudioPlayer.playStartGame();
        }

        private void GetCreatePlayers() {

            string playerName = "";

            do {
                outputProvider.WriteLine(MessageProvider.M_PromptPlayerName);
                playerName = inputProvider.Read();
            } while (string.IsNullOrWhiteSpace(playerName));

            players.Add(new HumanPlayer(new AltBlackjackMoveProvider(inputProvider), playerName));
        }
    }
}
