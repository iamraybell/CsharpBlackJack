using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {
    public class Deck : IDeck {
        public List<ICard> cards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICard GetCard() {
            throw new NotImplementedException();
        }

        public void Shuffle() {
            throw new NotImplementedException();
        }
    }
}
