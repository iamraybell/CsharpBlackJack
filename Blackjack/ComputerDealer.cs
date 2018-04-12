using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {
    class ComputerDealer : IPlayer {
        public IHand Hand { get; set; }
        public string Name { get; set; }

        public bool StillInPlay { get; private set; }
        public ComputerDealer()
        {
            StillInPlay = true;
        }



        public PlayerAction GetAction() {
            throw new NotImplementedException();
        }

        public void Hit() {
            throw new NotImplementedException();
        }

        public void Stand() {
            throw new NotImplementedException();
        }
    }
}
