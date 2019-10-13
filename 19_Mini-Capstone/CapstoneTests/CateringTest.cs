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
        public void ProductExistsTest()
        {
            Catering testClass = new Catering();

            bool result = testClass.ProductExists("B1", 2);
            Assert.AreEqual(true, result);

            result = testClass.ProductExists("SnickersBar", 2);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ProductAvailableTest()
        {
            Catering testClass = new Catering();

            bool result = testClass.ProductAvailable("E1", 2);
            Assert.AreEqual(true, result);

            result = testClass.ProductAvailable("E1", 51);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SufficientStockTest()
        {
            Catering testClass = new Catering();

            bool result = testClass.SufficientStock("A1", 2);
            Assert.AreEqual(true, result);

            result = testClass.SufficientStock("A2", 51);
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

            result = testClass.LessThan5000(5001);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ChangeToReturnTest()
        {
            Catering testClass = new Catering();
            Catering testClass2 = new Catering();
            Catering testClass3 = new Catering();
            Catering testClass4 = new Catering();
            Catering testClass5 = new Catering();
            Catering testClass6 = new Catering();
            Catering testClass7 = new Catering();
            Catering testClass8 = new Catering();
            Catering testClass9 = new Catering();
            Catering testClass10 = new Catering();
            Dictionary<decimal, int> result = new Dictionary<decimal, int>();
            Dictionary<decimal, int> expectedAnswer = new Dictionary<decimal, int>();

            decimal balance = testClass.AccountBalance = 500;
            testClass.ChangeToReturn();
            result = testClass.changeToReturn;
            expectedAnswer.Add(100M, 5);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass2.AccountBalance = 550;
            testClass2.ChangeToReturn();
            result = testClass2.changeToReturn;
            expectedAnswer.Add(50M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass3.AccountBalance = 570;
            testClass3.ChangeToReturn();
            result = testClass3.changeToReturn;
            expectedAnswer.Add(20M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass4.AccountBalance = 580;
            testClass4.ChangeToReturn();
            result = testClass4.changeToReturn;
            expectedAnswer.Add(10M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass5.AccountBalance = 585;
            testClass5.ChangeToReturn();
            result = testClass5.changeToReturn;
            expectedAnswer.Add(5M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass6.AccountBalance = 586;
            testClass6.ChangeToReturn();
            result = testClass6.changeToReturn;
            expectedAnswer.Add(1M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass7.AccountBalance = 586.50M;
            testClass7.ChangeToReturn();
            result = testClass7.changeToReturn;
            expectedAnswer.Add(.25M, 2);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass8.AccountBalance = 586.60M;
            testClass8.ChangeToReturn();
            result = testClass8.changeToReturn;
            expectedAnswer.Add(.1M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass9.AccountBalance = 586.65M;
            testClass9.ChangeToReturn();
            result = testClass9.changeToReturn;
            expectedAnswer.Add(.05M, 1);
            CollectionAssert.AreEquivalent(expectedAnswer, result);

            balance = testClass10.AccountBalance = 586.67M;
            testClass10.ChangeToReturn();
            result = testClass10.changeToReturn;
            expectedAnswer.Add(.01M, 2);
            CollectionAssert.AreEquivalent(expectedAnswer, result);
        }

    }

}
