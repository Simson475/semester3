using Core;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class UserTests
    {


        [SetUp]
        public void SetUp()
        {
            User.NextID = 1;
        }

        private User CreateUser()
        {
            return new User("test", "test", "test", 100m, "test@test.dk");
        }

        [Test]
        public void GetNextID_TwoCallsToGetNextId_GetTwoConcurrentValues()
        {
            // Arrange

            // Act
            int result1 = User.GetNextID();
            int result2 = User.GetNextID();

            // Assert
            Assert.IsTrue(result1 + 1 == result2);
        }

        [Test]
        public void ToString_PrintString_ExpectedStringReturned()
        {
            // Arrange
            User user = CreateUser();
            string expected = "test test (test@test.dk)";

            // Act
            string result = user.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Equals_TestIfEqualWithItself_ReturnsTrue()
        {
            // Arrange
            User user = CreateUser();

            // Act
            bool result = user.Equals(
                user);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_ChecksIfEqualWithOtherUser_ReturnsFalse()
        {
            // Arrange
            User user = CreateUser();
            User user2 = CreateUser();
            // Act
            bool result = user.Equals(
                user2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetHashCode_HashAUserTwice_HashValuesAreIdentical()
        {
            // Arrange
            User user = CreateUser();

            // Act
            int result1 = user.GetHashCode();
            int result2 = user.GetHashCode();

            // Assert
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void CompareTo_TwoDifferentUsers_ReturnMinus1()
        {
            // Arrange
            User user = CreateUser();
            User user2 = CreateUser();
            int expected = -1;

            // Act
            int result = user.CompareTo(
                user2);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
