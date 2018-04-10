using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack {
    public class Deck : IDeck {
        public List<ICard> Cards { get; set; }

        public ICard Draw() {
            throw new NotImplementedException();
        }

        public void Init() {
            throw new NotImplementedException();
        }

        public void Shuffle() {
            throw new NotImplementedException();
        }
    }
}
