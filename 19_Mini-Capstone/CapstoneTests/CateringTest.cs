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

        [TestMethod]
        public void IsPositiveTest()
        {
            Catering testClass = new Catering();

            bool result = testClass.IsPositive(10);
            Assert.AreEqual(true, result);

            result = testClass.IsPositive(-10);
            Assert.AreEqual(false, result);

            result = testClass.IsPositive(-500);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void LessThan5000Test()
        {
            Catering testClass = new Catering();

            bool result = testClass.LessThan5000(4999);
            Assert.AreEqual(true, result);

            result = testClass.LessThan5000(50001);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void ChangeReturnedTest()
        {
            Catering testClass = new Catering();
           decimal balance = testClass.accountBalance = 500;
           decimal change = testClass.amountDueBack = 250;
           //decimal result = (testClass.ChangeReturned();
            //string result = testClass.ChangeReturned();
            //Assert.IsTrue(result.Contains("));
        }
    }

}
