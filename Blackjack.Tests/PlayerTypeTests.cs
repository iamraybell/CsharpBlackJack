using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Enums;
using System.ComponentModel;

namespace Blackjack.Tests
{
    [TestClass]
    public class PlayerTypeTests
    {
        [TestMethod]
        public void TestCompterTypeReturnsCorrectString()
        {
            //arrange

            var computerType = PlayerType.Computer;
            var expectedReturn = "Computer";


            //act
            var results = PlayerTypeExtentions.GetString(computerType);

            //assert
            Assert.AreEqual(expectedReturn, results);

        }

    }
}
