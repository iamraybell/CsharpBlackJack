using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;
using Blackjack.Enums;

namespace Blackjack {
    public class Deck : IDeck {
        public List<ICard> Cards { get; set; }
        private List<ICard> Shuffler { get; set; }

        private ICardProvider cardProvider { get; set; }

        public Deck (ICardProvider cardProvider) {
            Cards = new List<ICard>();
            Shuffler = new List<ICard>();
            this.cardProvider = cardProvider;
            Init();
        }

        public ICard Draw() {
            if (Cards.Count == 0)
                throw new Exception();

            ICard card = Cards[0];
            Cards.RemoveAt(0);
            Shuffler.Add(card);

            return card;
        }

        public void Init() {
            Cards.Clear();
            Shuffler.Clear();
            Cards = cardProvider.GetCards().ToList();
            Shuffle();
        }

        public void Shuffle() {
            MoveCardsToShuffler();

            int cardsInDeck = Shuffler.Count;
            Random rnd = new Random();

            while (cardsInDeck > 0) {
                int tempIndex = rnd.Next(cardsInDeck);

                Cards.Add(Shuffler[tempIndex]);
                Shuffler.RemoveAt(tempIndex);

                cardsInDeck--;
            }
        }

        private void MoveCardsToShuffler() {
            while (Cards.Count > 0) {
                Shuffler.Add(Cards[0]);
                Cards.RemoveAt(0);
            }
        }
    }
}
