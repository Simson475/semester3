using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP007Delegates;
using System;
using System.Collections.Generic;

namespace OOP007.UnitTests
{
    [TestClass]
    public class StringJoinerTests
    {
        [TestMethod]
        public void Join3_ConcatABAndC_Returnsabc()
        {
            //Arrange
            string a = "a",
                b = "b",
                c = "c";
            StringJoin testFunc = (l, r) => l + r;
            string expectedResult = "abc";

            //Act
            string actualResult = StringJoiner.Join3(a, b, c, testFunc);

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void Join3_ConcatABAndCWithDots_ReturnsaDotbDotc()
        {
            //Arrange
            string a = "a",
                b = "b",
                c = "c";
            StringJoin testFunc = (l, r) => l + "." + r;
            string expectedResult = "a.b.c";

            //Act
            string actualResult = StringJoiner.Join3(a, b, c, testFunc);

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void Join3_OnlyReturnFirstParam_Returnsa()
        {
            //Arrange
            string a = "a",
                b = "b",
                c = "c";
            StringJoin testFunc = (l, r) => l;
            string expectedResult = "a";

            //Act
            string actualResult = StringJoiner.Join3(a, b, c, testFunc);

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void JoinAllString_ConcatListOfStrings_Returnhellodelegates()
        {

            //Arrange
            List<string> testList = new List<string>() { "hello", " ", "delegates" };
            Func<string, string, string> testFunction = (l, r) => l + r;
            string expected = "hello delegates";
            //Act
            string result = StringJoiner.JoinAllString(testList, testFunction);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }

    [TestClass]
    public class TwicerTester
    {
        [TestMethod]
        public void Twice_Multiply2By2Twice_returns8()
        {

            //Arrange
            int value = 2;
            Func<int, int> testFunction = v => v * 2;
            int expected = 8;
            //Act
            int result = Twicer.Twice(testFunction, value);
            //Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Twice_ConcatHelloWorldToHelloWorldTwice_returnsHellWorldx4()
        {

            //Arrange
            string value = "Hello World ";
            Func<string, string> testFunction = v => v + v;
            string expected = "Hello World Hello World Hello World Hello World ";
            //Act
            string result = Twicer.Twice(testFunction, value);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}

