using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class Hand : IHand {
        public List<ICard> Cards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddCard(ICard card) {
            throw new NotImplementedException();
        }

        public int GetTotalValue(List<ICard> hand) {
            int total = 0;
            int aceCount = hand.Where(x => x.Value == CardValue.Ace).Count();

            foreach (ICard card in hand) {
                total += card.GetIntValue();
            }

            while (total > 21 && aceCount > 0) {
                total -= 10;
            }

            return total;
        }

        public int CompareTo(IHand other) {
            int myHand = GetTotalValue(Cards);
            int otherHand = GetTotalValue(other.Cards);

            return myHand - otherHand;
        }
    }
}
