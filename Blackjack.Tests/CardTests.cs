using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Blackjack.Enums;
using System.Collections.Generic;

namespace Blackjack.Tests {

    [TestClass]
    public class CardTests {
        
        [TestMethod]
        public void KingIsTen()
        {
            Assert.AreEqual(10, Card.Create(CardName.King, CardSuit.Hearts).Value);
        }



        [TestMethod]
        public void TestCard() {
            // arrange
      
            CardSuit expSuit = CardSuit.Clubs;
            CardName expName = CardName.Ace;
            int expVal = 11;

            // act
            var card = Card.Create( CardName.Ace, CardSuit.Clubs);

            // assert
            Assert.AreEqual(expSuit, card.Suit);
            Assert.AreEqual(expName, card.Name);
            Assert.AreEqual(expVal, card.Value);
            
            
        }

        [TestMethod]
        public void TestToStringWhenNotHidden() {
            // arrange
            Card card = Card.Create(CardName.Ace, CardSuit.Clubs);
            string exp = "[A]";
            card.IsHidden = false;


            // act
            string act = card.ToString();
           
            // assert
            Assert.AreEqual(exp, act);
            

        }
    }
}
