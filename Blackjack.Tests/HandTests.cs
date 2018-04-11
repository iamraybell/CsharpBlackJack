using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;
using Blackjack.Enums;
using Moq;
using System.Collections.Generic;

namespace Blackjack.Tests {
    [TestClass]
    public class HandTests {
        [TestMethod]
        public void TestGetTotalValue() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);

            int expected = 20;

            // act

            int actual = hand.GetTotalValue(hand.Cards);

            // assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGetTotalValueChangeAce() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardAce.Object);

            int expected = 21;

            // act

            int actual = hand.GetTotalValue(hand.Cards);

            // assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGetTotalValueBust() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardAce.Object);

            int expected = 29;

            // act

            int actual = hand.GetTotalValue(hand.Cards);

            // assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestCompareToLess() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);
            hand2.AddCard(mockICardAce.Object);

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);



            //int expected = 29;

            // act

            bool lessThan = hand.CompareTo(hand2) < 0;

            // assert

            Assert.IsTrue(lessThan);

        }

        [TestMethod]
        public void TestCompareToEqual() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);



            //int expected = 29;

            // act

            bool equalTo = hand.CompareTo(hand2) == 0;

            // assert

            Assert.IsTrue(equalTo);

        }

        [TestMethod]
        public void TestCompareToGreater() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);



            //int expected = 29;

            // act

            bool greaterThan = hand.CompareTo(hand2) > 0;

            // assert

            Assert.IsTrue(greaterThan);

        }


        [TestMethod]
        public void TestCompareToBustLess() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardNine.Object);



            //int expected = 29;

            // act

            bool lessThan = hand.CompareTo(hand2) < 0;

            // assert

            Assert.IsTrue(lessThan);

        }

        [TestMethod]
        public void TestCompareToBustEqual() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);
            hand2.AddCard(mockICardNine.Object);
            hand2.AddCard(mockICardNine.Object);

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardNine.Object);
            hand.AddCard(mockICardNine.Object);



            //int expected = 29;

            // act

            bool equalTo = hand.CompareTo(hand2) == 0;

            // assert

            Assert.IsTrue(equalTo);

        }

        [TestMethod]
        public void TestCompareToBustGreater() {

            // arrange
            var mockICardAce = new Mock<ICard>(MockBehavior.Strict);
            mockICardAce.Setup(x => x.Value).Returns(11);
            mockICardAce.Setup(x => x.Name).Returns(CardName.Ace);

            var mockICardNine = new Mock<ICard>(MockBehavior.Strict);
            mockICardNine.Setup(x => x.Value).Returns(9);
            mockICardNine.Setup(x => x.Name).Returns(CardName.Nine);

            //List<ICard> hand = new List<ICard>() { mockICardAce.Object, mockICardNine.Object };

            Hand hand = new Hand();
            Hand hand2 = new Hand();

            hand2.AddCard(mockICardAce.Object);
            hand2.AddCard(mockICardNine.Object);
            hand2.AddCard(mockICardNine.Object);
            hand2.AddCard(mockICardNine.Object);

            hand.AddCard(mockICardAce.Object);
            hand.AddCard(mockICardAce.Object);



            //int expected = 29;

            // act

            bool greaterThan = hand.CompareTo(hand2) > 0;

            // assert

            Assert.IsTrue(greaterThan);

        }


        

    }
}
