using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP007Delegates;
using System;

namespace OOP007.UnitTests
{
    [TestClass]
    public class ExistanceCheckerTests
    {
        [TestMethod]
        public void Exists_CheckIf5IsInTheList_ReturnsTrue()
        {
            //Arrange
            int[] arrayToTest = new int[] { 5, 6 };
            Predicate<int> testFunction = a => a == 5;
            bool expectedResult = true;

            //Act
            bool exists = ExistanceChecker.Exists(testFunction, arrayToTest);

            //Assert
            Assert.AreEqual(exists, expectedResult);
        }

        [TestMethod]
        public void Exists_CheckIfyIsInTheList_ReturnsFalse()
        {
            //Arrange
            int[] arrayToTest = new int[] { 5, 6 };
            Predicate<int> testFunction = a => a == 7;
            bool expectedResult = false;

            //Act
            bool exists = ExistanceChecker.Exists(testFunction, arrayToTest);

            //Assert
            Assert.AreEqual(exists, expectedResult);
        }
    }
}
