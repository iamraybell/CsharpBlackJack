using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass]
    public class MessageProviderTests
    {
        [TestMethod]
        public void TestMessageProviderConstructor()
        {
            // arrange
            string welcome = "Welcome";
            string rules = "List of rules";

            // act
            MessageProvider messageProvider = new MessageProvider(welcome, rules);

            // assert
            Assert.AreEqual(welcome, messageProvider.Welcome);
            Assert.AreEqual(rules, messageProvider.Rules);
        }

        [TestMethod]
        public void TestPrintWelcomeWithoutInput()
        {
            // arrange
            string welcome = "Welcome";
            string rules = "List of rules";
            StringWriter stringWriter = new StringWriter();

            // act
            MessageProvider messageProvider = new MessageProvider(welcome, rules);
            Console.SetOut(stringWriter);
            messageProvider.printWelcome();

            // assert
            Assert.AreEqual(welcome + "\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void TestPrintWelcomeWithInput()
        {
            // arrange
            string welcomeInstanceData = "Welcome";
            string welcome = "Welcome to the game!";
            string rules = "List of rules";
            StringWriter stringWriter = new StringWriter();

            // act
            MessageProvider messageProvider = new MessageProvider(welcomeInstanceData, rules);
            Console.SetOut(stringWriter);
            messageProvider.printWelcome(welcome);

            // assert
            Assert.AreEqual(welcome + "\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void TestPrintRulesWithoutInput()
        {
            // arrange
            string welcome = "Welcome";
            string rules = "List of rules";
            StringWriter stringWriter = new StringWriter();

            // act
            MessageProvider messageProvider = new MessageProvider(welcome, rules);
            Console.SetOut(stringWriter);
            messageProvider.printRules();

            // assert
            Assert.AreEqual(rules + "\r\n", stringWriter.ToString());
        }
        [TestMethod]
        public void TestPrintRulesWithInput()
        {
            // arrange
            string welcome = "Welcome";
            string rulesInstanceData = "List of rules";
            string rules = "These are the game rules";
            StringWriter stringWriter = new StringWriter();

            // act
            MessageProvider messageProvider = new MessageProvider(welcome, rulesInstanceData);
            Console.SetOut(stringWriter);
            messageProvider.printRules();

            // assert
            Assert.AreEqual(rules + "\r\n", stringWriter.ToString());
        }
    }
}
