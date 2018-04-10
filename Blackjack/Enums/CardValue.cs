using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Blackjack.Enums
{
    public enum CardValue
    {
        [Description("A")]
        Ace = 11,

        [Description("2")]
        Two = 2,
        [Description("3")]
        Three = 3,
        [Description("4")]
        Four = 4,
        [Description("5")]
        Five = 5,
        [Description("6")]
        Six = 6,
        [Description("7")]
        Seven = 7,
        [Description("8")]
        Eight = 8,
        [Description("9")]
        Nine = 9,
        [Description("10")]
        Ten = 10,
        [Description("J")]
        Jack = 10,
        [Description("Q")]
        Queen = 10,
        [Description("K")]
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
