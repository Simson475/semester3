using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP007Delegates;
using System;
using System.Collections.Generic;

namespace OOP007.UnitTests
{
    [TestClass]
    public class JoinerTests
    {
        [TestMethod]
        public void JoinAllGeneric_testsToSeeIfStringsConcatenate_ReturnsYesSir()
        {
            //Arrange
            List<string> testList = new List<string>() { "Yes ", "Sir" };
            Func<string, string, string> testFunction = (l, r) => l + r;
            string expectedResult = "Yes Sir";

            //Act
            string saved = Joiner.JoinAllGeneric(testList, testFunction);

            //Assert
            Assert.AreEqual(saved, expectedResult);
        }

        [TestMethod]
        public void JoinAllGeneric_testsToSeeIfNumbersAdd_Returns23()
        {
            //Arrange
            List<int> testList = new List<int>() { 15, 3, 5 };
            Func<int, int, int> testFunction = (l, r) => l + r;
            int expectedResult = 23;

            //Act
            int saved = Joiner.JoinAllGeneric(testList, testFunction);

            //Assert
            Assert.AreEqual(saved, expectedResult);
        }
    }
}
