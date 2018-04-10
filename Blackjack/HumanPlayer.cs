using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {
    class HumanPlayer : IPlayer {
        public IHand Hand { get; set; }
        public string Name { get; set; }

        public void Hit() {
            throw new NotImplementedException();
        }

        public void Stand() {
            throw new NotImplementedException();
        }
    }
}
