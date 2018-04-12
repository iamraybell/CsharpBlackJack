using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass]
    public class ConsoleOutputProviderTests
    {
        [TestMethod]
        public void TestWrite()
        {
            // arrange
            string output = "Hello World";
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            StringWriter stringWriter = new StringWriter();

            // act
            Console.SetOut(stringWriter);
            consoleOutputProvider.Write(output); //this writes to the stringwriter, not the console
            // \r\n

            // assert
            Assert.AreEqual(output, stringWriter.ToString());
        }

        [TestMethod]
        public void TestWriteLineWithInput()
        {
            // arrange
            string output = "Hello World";
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            StringWriter stringWriter = new StringWriter();

            // act
            Console.SetOut(stringWriter);
            consoleOutputProvider.WriteLine(output); //this writes to the stringwriter, not the console

            // assert
            Assert.AreEqual(output + "\r\n", stringWriter.ToString());
        }
        [TestMethod]
        public void TestWriteLineWithoutInput()
        {
            // arrange
            ConsoleOutputProvider consoleOutputProvider = new ConsoleOutputProvider();
            StringWriter stringWriter = new StringWriter();

            // act
            Console.SetOut(stringWriter);
            consoleOutputProvider.WriteLine(); //this writes to the stringwriter, not the console

            // assert
            Assert.AreEqual("\r\n", stringWriter.ToString());
        }
    }
}
