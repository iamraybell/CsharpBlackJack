using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Enums
{
    public enum CardValue
    {
        Ace = 11,

        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 10,
        Queen = 10,
        King = 10,
    };
/*  POTENTIAL WAY TO INITIALIZE A DECK OF CARDS
 * 
    CardSuit[] css = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>().ToArray();
    CardValue[] cvs = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().ToArray();

            foreach (CardSuit cs in css) {
                foreach (CardValue cv in cvs) {
                    Card card = new Card(cs, cv);
                }
            }
*/
}
