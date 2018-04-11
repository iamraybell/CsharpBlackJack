using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {
    class MessageProvider : IMessageProvider {
        public string M_Welcome { get; set; }
        public string M_Rules { get; set; }
    }
}
