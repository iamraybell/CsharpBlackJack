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

       

        public Deck () {
            Cards = new List<ICard>();
            Shuffler = new List<ICard>();
           
            Init();
        }
        public IEnumerable<ICard> GetCards()
        {
            List<ICard> listOfCardsToReturn = new List<ICard>();
            CardSuit[] suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>().ToArray();
            CardName[] names = Enum.GetValues(typeof(CardName)).Cast<CardName>().ToArray();

            foreach (CardSuit suit in suits)
            {
                foreach (CardName name in names)
                {
                    int valueOfName = GetValue(name);
                    Card cardToAddtoList = new Card(suit, name, valueOfName);
                    listOfCardsToReturn.Add(cardToAddtoList);
                }
            }

            return listOfCardsToReturn;
        }



        public int GetValue(CardName name)
        {
            string nameToString = name.GetString();
            int value;
            bool results = int.TryParse(nameToString, out value);

            if (results)
            {
                return value;
            }
            else if (name == CardName.Ace)
            {
                return 11;
            }
            return 10;
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
            Cards = GetCards().ToList();
        }

        public void Shuffle() {
            Init();
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
