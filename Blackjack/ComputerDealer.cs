﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack {
    public class ComputerDealer : IPlayer {
        public IHand Hand { get; set; }
        public string Name { get; set; }

        public PlayerAction GetAction() {
            throw new NotImplementedException();
        }

        public void Hit() {
            throw new NotImplementedException();
        }

        public void Stand() {
            throw new NotImplementedException();
        }



        /// <summary>
        /// This method draws cards until the dealers
        /// hand is greater or equal to 17 and the dealer
        /// does not bust (over 21).
        /// </summary>
        public int DealerDraw(IDeck deck)
        {
            const int MAX_VALUE = 21;
            const int MIN_VALUE = 17;

            //Dealers card value
            var cardValue = Hand.GetTotalValue(Hand.Cards);

            //Draw cards until the dealers value is below min and not above max
            while (cardValue < MIN_VALUE && !(cardValue > MAX_VALUE))
            {
                var newCard = deck.Draw();

                //Draw Card
                Hand.AddCard(newCard);

                //Update Dealers card value
                cardValue = Hand.GetTotalValue(Hand.Cards);
            }
            return cardValue;
        }


    }
}

