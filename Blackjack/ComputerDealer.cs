using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {
    class ComputerDealer : IPlayer {
        public IHand hand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
