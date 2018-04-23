using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;
using Blackjack.Enums;
using Moq;
using System.Collections.Generic;

namespace Blackjack.Tests {
    [TestClass]
    public class DeckTests {
        [TestMethod]
        public void TestDeck() {
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardTwo = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Two);

            var mockICardThree = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Three);

            var mockICardFour = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Four);

            List<ICard> cards = new List<ICard>() { mockICardAce.Object, mockICardTwo.Object, mockICardThree.Object, mockICardFour.Object };

            var deck= new Mock<IDeck>(MockBehavior.Strict);
            deck.Setup(x => x.GetCards()).Returns(cards);

            

            Assert.IsNotNull(deck);

        }

  





    }
}
