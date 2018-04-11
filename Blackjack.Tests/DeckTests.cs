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

            var mockICardProvider = new Mock<ICardProvider>(MockBehavior.Strict);
            mockICardProvider.Setup(x => x.GetCards()).Returns(cards);

            Deck deck = new Deck(mockICardProvider.Object);

            Assert.IsNotNull(deck.Cards);

        }

        [TestMethod]
        public void TestDeckShuffleFunc() {
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardTwo = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Two);

            var mockICardThree = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Three);

            var mockICardFour = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Four);

            List<ICard> cards = new List<ICard>() { mockICardAce.Object, mockICardTwo.Object, mockICardThree.Object, mockICardFour.Object };

            var mockICardProvider = new Mock<ICardProvider>(MockBehavior.Strict);
            mockICardProvider.Setup(x => x.GetCards()).Returns(cards);

            Deck deck = new Deck(mockICardProvider.Object);

            deck.Shuffle();

            Assert.IsNotNull(deck.Cards);

        }

        [TestMethod]
        public void TestDeckDraw() {
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            List<ICard> cards = new List<ICard>() { mockICardAce.Object };

            var mockICardProvider = new Mock<ICardProvider>(MockBehavior.Strict);
            mockICardProvider.Setup(x => x.GetCards()).Returns(cards);

            Deck deck = new Deck(mockICardProvider.Object);

            ICard card = deck.Draw();

            Assert.AreEqual(mockICardAce.Object.Name, card.Name);
            Assert.AreEqual(0, deck.Cards.Count);

        }


    }
}
