using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {

    public class BlackjackMoveProvider : IMoveProvider {

        private IInputProvider inputProvider { get; set; }

        public BlackjackMoveProvider(IInputProvider ip) {
            inputProvider = ip;
        }

        public PlayerAction GetAction() {
            String input = inputProvider.Read().ToLower();

            PlayerAction pa = PlayerAction.Stand;

            if (input.Equals("hit")) {
                pa = PlayerAction.Hit;
            } else if (input.Equals("quit")) {
                pa = PlayerAction.Quit;
            }

            return pa;
        }

        public void InitiateLoop() {
            //throw new NotImplementedException();
        }

        public void SetCurrentPlayer(IPlayer Player) {
            //throw new NotImplementedException();
        }
    }
}
