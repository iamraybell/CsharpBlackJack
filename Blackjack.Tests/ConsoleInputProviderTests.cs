using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests {
    [TestClass]
    public class ConsoleInputProviderTests {
        [TestMethod]
        public void TestRead() {

            //arrange
            ConsoleInputProvider consoleInputProvider = new ConsoleInputProvider();
            var inputString = "This is the expected string!";

            //act
            var sr = new StringReader(inputString);
            Console.SetIn(sr);

            var actual = consoleInputProvider.Read();

            //assert
            Assert.AreEqual(inputString, actual);

        }
    }
}
