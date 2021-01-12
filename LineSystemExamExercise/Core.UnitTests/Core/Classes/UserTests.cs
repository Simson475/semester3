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
        public void Equals_TestIfEqualWithProduct_ReturnsFalse()
        {
            // Arrange
            User user = CreateUser();
            Product product = Substitute.For<Product>();
            // Act
            bool result = user.Equals(
                product);

            // Assert
            Assert.IsFalse(result);
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

        [Test]
        [TestCase("test@email.com")]
        [TestCase("7es7@email.com")]
        [TestCase("test.valid@email.com")]
        [TestCase("test_valid@email.com")]
        [TestCase("test-valid@email.com")]
        [TestCase("test@e.mail.com")]
        [TestCase("test@e-mail.com")]
        [TestCase("test@3m4il.com")]
        [TestCase("test@Email.com")]
        [TestCase("Test@Email.com")]
        public void Email_EmailIsValid_EmailShouldBeSet(string email)
        {
            //arrange
            User user = CreateUser();
            //act
            user.Email = email;
            //assert
            Assert.AreEqual(email, user.Email);
        }

        [Test]
        [TestCase("!invalid@email.com")]
        [TestCase("invalid@!email.com")]
        [TestCase("invalid@-email.com")]
        [TestCase("invalid@.email.com")]
        public void Email_EmailIsInvalid_EmailShouldNotBeSet(string email)
        {
            //arrange
            User user = CreateUser();
            //act
            try
            {
                user.Email = email;

            }
            catch (ArgumentException)
            {
                //assert

                Assert.Pass();
                return;
            }
            Assert.Fail();
        }

        [Test]
        [TestCase("bob", "nielsen")]
        [TestCase("kurt", "larse")]
        [TestCase("john", "pilgrim")]
        [TestCase("sylvester", "smith")]
        [TestCase("doe", "messerschmidt")]
        public void FullName_FullNameIsRequested_FullNameIsCorrect(string firstName, string LastName)
        {
            //arrange
            User user = CreateUser();
            user.FirstName = firstName;
            user.LastName = LastName;
            string expected = $"{user.FirstName} {user.LastName}";
            //act
            string result = user.FullName;

            //assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("username")]
        [TestCase("username1")]
        [TestCase("us12me")]
        [TestCase("us_ername1")]
        [TestCase("usera123nl21ame")]
        public void Username_UsernameIsValid_UsernameIsSet(string username)
        {
            //arrange
            User user = CreateUser();
            //act
            user.Username = username;
            //assert
            Assert.AreEqual(username, user.Username);
        }

        [Test]
        [TestCase("!#¤%&/()=?")]
        [TestCase("us1^2me")]
        [TestCase("user1!a123nl21ame")]
        public void Username_UsernameIsInvalid_UsernameIsNotSet(string username)
        {
            //arrange
            User user = CreateUser();
            //act
            try
            {
                user.Username = username;

            }
            catch (ArgumentException)
            {
                Assert.Pass();
                return;
            }
            //assert
            Assert.Fail(username);
        }

        [Test]
        public void FirstName_FirstNameIsNull_ErrorIsThrown()
        {
            //arrange
            User user = CreateUser();
            //act
            try
            {
                user.FirstName = null;

            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
                return;
            }
            //assert
            Assert.Fail();
        }

        [Test]
        public void Username_usernameIsNull_ErrorIsThrown()
        {
            //arrange
            User user = CreateUser();
            //act
            try
            {
                user.Username = null;

            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
                return;
            }
            //assert
            Assert.Fail();
        }

        [Test]
        public void LastName_LastNameIsNull_ErrorIsThrown()
        {
            //arrange
            User user = CreateUser();
            //act
            try
            {
                user.LastName = null;

            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
                return;
            }
            //assert
            Assert.Fail();
        }
    }
}
