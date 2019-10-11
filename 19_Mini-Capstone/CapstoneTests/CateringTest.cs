using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void ConvertMoneyToDecimalTest()
        {
            Catering testClass = new Catering();

            bool result = testClass.ConvertMoneyToDecimal("8");
            Assert.AreEqual(true, result);

            result = testClass.ConvertMoneyToDecimal("8.8");
            Assert.AreEqual(true, result);

            result = testClass.ConvertMoneyToDecimal("eight");
            Assert.AreEqual(false, result);
        }

    }

}
