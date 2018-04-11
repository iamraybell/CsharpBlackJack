using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack
{
    public  class BlackJackCardProvider: ICardProvider
    {
       


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
            return 10;
        }
    }
}
