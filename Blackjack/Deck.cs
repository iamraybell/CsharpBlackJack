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

        public Deck() {
            Init();
        }

        public Deck(List<ICard> cards) {
            Cards = cards;
        }

        public ICard Draw() {
            throw new NotImplementedException();
        }

        public void Init() {

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
