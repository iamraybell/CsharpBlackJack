using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces {
    public interface IDeck {
        List<ICard> Cards { get; set; }

        void Init();

        void Shuffle();

        ICard Draw();

    }
}
