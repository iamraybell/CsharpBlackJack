﻿using System;
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
            CardValue expValue = CardValue.Ace;

            // act
            card = new Card(CardSuit.Clubs, CardValue.Ace, true);
            card2 = new Card(CardSuit.Clubs, CardValue.Ace);

            // assert
            Assert.AreEqual(expSuit, card.Suit);
            Assert.AreEqual(expSuit, card2.Suit);
            Assert.AreEqual(expValue, card.Value);
            Assert.AreEqual(expValue, card2.Value);
            Assert.IsTrue(card.IsHidden);
            Assert.IsFalse(card2.IsHidden);
        }

        [TestMethod]
        public void TestGetIntValue() {
            // arrange
            CardValue[] cvs = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().ToArray();
            List<Card> cards = new List<Card>();

            foreach(CardValue cv in cvs) {
                cards.Add(new Card(CardSuit.Clubs, cv));
            }

            // act

            // assert

            Assert.AreEqual(11, cards[0].GetIntValue());
            Assert.AreEqual(2, cards[1].GetIntValue());
            Assert.AreEqual(3, cards[2].GetIntValue());
            Assert.AreEqual(4, cards[3].GetIntValue());
            Assert.AreEqual(5, cards[4].GetIntValue());
            Assert.AreEqual(6, cards[5].GetIntValue());
            Assert.AreEqual(7, cards[6].GetIntValue());
            Assert.AreEqual(8, cards[7].GetIntValue());
            Assert.AreEqual(9, cards[8].GetIntValue());
            Assert.AreEqual(10, cards[9].GetIntValue());
            Assert.AreEqual(10, cards[10].GetIntValue());
            Assert.AreEqual(10, cards[11].GetIntValue());
            Assert.AreEqual(10, cards[12].GetIntValue());
        }

        [TestMethod]
        public void TestToString() {
            // arrange
            Card card = new Card(CardSuit.Clubs, CardValue.Ace);
            Card card2 = new Card(CardSuit.Clubs, CardValue.Ace, true);

            string exp = "[A]";
            string exp2 = "[*]";

            // act

            string act = card.ToString();
            string act2 = card2.ToString();

            // assert
            Assert.AreEqual(exp, act);
            Assert.AreEqual(exp2, act2);

        }
    }
}