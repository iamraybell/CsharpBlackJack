using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;
using Moq;
using Blackjack.Enums;
using System.Collections.Generic;

namespace Blackjack.Tests {

    [TestClass]
    public class BlackjackWinCheckerTests
    {
        [TestMethod]
        public void TestIsWin()
        {
            //arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            Hand hand1 = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);

            hand1.AddCard(mockICardAce.Object);
            hand1.AddCard(mockICardAce.Object);
            hand1.AddCard(mockICardNine.Object);


            var blackJackWinChecker = new BlackjackWinChecker();
            var expected1 = WinState.win;
            var expected2 = WinState.lose;
            var expected3 = WinState.draw;


            //act
            var actual1 = blackJackWinChecker.IsWin(hand2,hand1);
            var actual2 = blackJackWinChecker.IsWin(hand1, hand2);
            var actual3 = blackJackWinChecker.IsWin(hand1, hand1);

            //assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);

        }
    }
}
