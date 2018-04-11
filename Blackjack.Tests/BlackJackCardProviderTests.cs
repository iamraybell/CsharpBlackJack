using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Enums;
using System.Collections;
using System.Collections.Generic;
using Blackjack.Interfaces;
using System.Linq;

namespace Blackjack.Tests
{
    [TestClass]
    public class BlackJackCardProviderTests
    {
        [TestMethod]
        public void TestGetValuesReturnsWhenNumber()
        {
            int expectedValue = 8;
            var BJCardProvider = new BlackJackCardProvider();

            int returnValue = BJCardProvider.GetValue(CardName.Eight);

            Assert.AreEqual(expectedValue, returnValue);
        }
        [TestMethod]
        public void TestGetValuesReturnsWhenNotNumber()
        {
            int expectedValue = 10;
            var BJCardProvider = new BlackJackCardProvider();
            int returnValue = BJCardProvider.GetValue(CardName.Ace);

            Assert.AreEqual(expectedValue, returnValue);
        }

        [TestMethod]
        public void TestGetCardsReturns52()
        {
            int expectedValue = 52;
            var BJCardProvider = new BlackJackCardProvider();
            var returnedCards = BJCardProvider.GetCards();
            Assert.AreEqual(expectedValue, returnedCards.Count());
        }
    }
}
