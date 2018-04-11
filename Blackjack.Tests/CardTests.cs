using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Blackjack.Enums;
using System.Collections.Generic;

namespace Blackjack.Tests {
    [TestClass]
    public class CardTests {
        [TestMethod]
        public void TestCard() {
            // arrange
            Card card;
            Card card2;

            CardSuit expSuit = CardSuit.Clubs;
            CardName expName = CardName.Ace;

            int expVal = 11;

            // act
            card = new Card(CardSuit.Clubs, CardName.Ace, expVal);

            // assert
            Assert.AreEqual(expSuit, card.Suit);
            Assert.AreEqual(expName, card.Name);
            Assert.AreEqual(expVal, card.Value);
            Assert.IsTrue(card.IsHidden);
            
        }

        [TestMethod]
        public void TestToString() {
            // arrange
            Card card = new Card(CardSuit.Clubs, CardName.Ace, 11);
            Card card2 = new Card(CardSuit.Clubs, CardName.Ace, 11);

            string exp = "[A]";
            string exp2 = "[*]";

            // act

            card.IsHidden = false;

            string act = card.ToString();
            string act2 = card2.ToString();

            // assert
            Assert.AreEqual(exp, act);
            Assert.AreEqual(exp2, act2);

        }
    }
}
