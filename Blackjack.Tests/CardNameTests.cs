using Blackjack.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Blackjack.Tests
{
    [TestClass]
    public class CardNameTests
    {

        [TestMethod]
        public void TestsAllDescriptionsNotNull()
        {
            List<CardName> userNames = Enum.GetValues(typeof(CardName)).Cast<CardName>().ToList();

            foreach(var name in userNames)
            {
                Extensions.GetString(name);
                Assert.IsNotNull(name);
            }
            

    }

}
}

