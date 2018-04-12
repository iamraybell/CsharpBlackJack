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
        public void TestDealerDrawBust()
        {
            //arrange
            var computerDealer = new ComputerDealer();

            var card = new Mock<ICard>(MockBehavior.Strict);
            card.Setup(x => x.Value).Returns(5);

            List<ICard> handCards = new List<ICard>()
            {
                card.Object,
                card.Object,
                card.Object,
                card.Object,
                card.Object
            };

            var deck = new Mock<IDeck>(MockBehavior.Strict);
            deck.Setup(x => x.Draw()).Returns(card.Object);

            var hand = new Mock<IHand>(MockBehavior.Strict);
            hand.Setup(x => x.GetTotalValue(It.IsAny<List<ICard>>())).Returns(GetTotalHelper(handCards));
            hand.Setup(x => x.Cards).Returns(handCards);
            hand.Setup(x => x.AddCard(card.Object)).Verifiable();

            computerDealer.Hand = hand.Object;

            var expected = 25;
            //act
            var actual = computerDealer.DealerDraw(deck.Object);

            //assign
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDealerDrawNoDraw()
        {
            //arrange
            var computerDealer = new ComputerDealer();

            var card = new Mock<ICard>(MockBehavior.Strict);
            card.Setup(x => x.Value).Returns(4);

            List<ICard> handCards = new List<ICard>()
            {
                card.Object,
                card.Object,
                card.Object,
                card.Object,
                card.Object
            };

            var deck = new Mock<IDeck>(MockBehavior.Strict);
            deck.Setup(x => x.Draw()).Returns(card.Object);

            var hand = new Mock<IHand>(MockBehavior.Strict);
            hand.Setup(x => x.GetTotalValue(It.IsAny<List<ICard>>())).Returns(GetTotalHelper(handCards));
            hand.Setup(x => x.Cards).Returns(handCards);
            hand.Setup(x => x.AddCard(card.Object)).Verifiable();

            computerDealer.Hand = hand.Object;

            var expected = 20;
            //act
            var actual = computerDealer.DealerDraw(deck.Object);

            //assign
            Assert.AreEqual(expected, actual);
        }
        private int GetTotalHelper(List<ICard> cards)
        {
            var sum = 0;
            
            for(int i = 0; i< cards.Count; ++i)
            {
                sum += cards[i].Value;
            }
            return sum;
        }
    }
}
