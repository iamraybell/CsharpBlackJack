using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics;

namespace Blackjack.Enums
{
    public enum CardName
    {
        [Description("A")]
        Ace,
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


    public static class Extensions
    {

        private static string GetCardDisplayName(CardName value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                throw new Exception($"Should never happen! Value is '{value}'.");
            }
        }

        /// <summary>
        /// Gets a human readable representation of <paramref name="cv"/>.
        /// </summary>
        public static string GetString(this CardName cv)
        {

            return GetCardDisplayName(cv);
        }
    }

}
      
