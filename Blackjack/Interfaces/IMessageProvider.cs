using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IMessageProvider
    {
        string M_Welcome { get; set; }
        string M_Rules { get; set; }

        // Add more properties as needed
    }
}
