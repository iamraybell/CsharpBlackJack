using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Blackjack.Enums
{
    public enum CardValue
    {
        [Description("A")]
        Ace = 1,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five,
        [Description("6")]
        Six,
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten,
        [Description("J")]
        Jack,
        [Description("Q")]
        Queen,
        [Description("K")]
        King,
    };

    public static class Extensions {

        private static string GetEnumDescription(CardValue value) {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0) {
                return attributes[0].Description;
            } else {
                return value.ToString();
            }
        }

        public static string GetString(this CardValue cv) {

            return GetEnumDescription(cv);
        }

        public static int GetIntValue(this CardValue cv) {
            int retInt = (int) cv;

            switch (cv) {
                case CardValue.Ace:
                    retInt = 11;
                    break;
                
                case CardValue.Jack:
                    retInt = 10;
                    break;
                
                case CardValue.Queen:
                    retInt = 10;
                    break;
                
                case CardValue.King:
                    retInt = 10;
                    break;              
                
            }

            return retInt;
        }
    }

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
