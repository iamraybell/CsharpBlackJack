using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Blackjack.Interfaces;

namespace Blackjack.Tests
{
    [TestClass]
    public class ComputerDealerTests
    {
        [TestMethod]
        public void TestDealerDraw()
        {
            //arrange
            var card = new Mock<ICard>(MockBehavior.Strict);
            
            var deck = new Mock<IDeck>(MockBehavior.Strict);
            var hand = new Mock<IHand>(MockBehavior.Strict);
            //hand.Setup(x => x.AddCard())

            //act

            //assign

        }
    }
}
