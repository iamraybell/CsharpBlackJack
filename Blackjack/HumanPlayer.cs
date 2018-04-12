using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {
    class HumanPlayer : IPlayer {
        public IHand Hand { get; set; }
        public string Name { get; set; }
        public bool StillInPlay { get; set; }

        private IMoveProvider moveProvider { get; set; }

        public HumanPlayer() { }

        public HumanPlayer(IMoveProvider moveProvider, string name) {
            this.moveProvider = moveProvider;
            StillInPlay = true;
            Hand = new Hand();
            Name = name;
        }

        public PlayerAction GetAction() {
            return moveProvider.GetAction();
            //throw new NotImplementedException();
        }

        public void Hit() {
            throw new NotImplementedException();
        }

        public void Stand() {
            throw new NotImplementedException();
        }

        public int GetBet() {
            throw new NotImplementedException();
        }

        public void AddCard(ICard card) {
            Hand.AddCard(card);
            if (Hand.GetTotalValue(Hand.Cards) >= 21) {
                StillInPlay = false;
            }
        }

        public void ClearHand() {
            Hand.Cards = new List<ICard>();
            StillInPlay = true;
        }

        public void InvokeSpecialAction(IDeck deck) {
            throw new NotImplementedException();
        }
    }
}
