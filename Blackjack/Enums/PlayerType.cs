using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Blackjack.Enums
{
    public enum PlayerType
    {
        
        Human,
        
        Computer

    }
    public static class PlayerTypeExtentions
    {
        public static string GetString(this PlayerType value)
        {
            switch (value)
            {
                case PlayerType.Computer:
                    return "Computer";
                case PlayerType.Human:
                    return "Human";
                default:
                   throw new InvalidEnumArgumentException();
            }
        }
    }
}
