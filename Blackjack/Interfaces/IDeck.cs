using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces {
    public interface IDeck {
        List<ICard> cards { get; set; }

        void Shuffle();

        ICard GetCard();

    }
}
