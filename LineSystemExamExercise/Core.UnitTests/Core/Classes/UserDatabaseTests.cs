using Core;
using NSubstitute;
using NUnit.Framework;
using System.IO;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class UserDatabaseTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private UserDatabase CreateUserDatabase()
        {
            return new UserDatabase();
        }

        [Test]
        public void ImportUsers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            UserDatabase userDatabase = CreateUserDatabase();
            userDatabase.Path = "../../../../LineSystemExamExercise/ImportFiles\\users.csv";
            string expected = "Nancy Davolio (ndavo@sample.stregsystem.dk)";
            // Act
            userDatabase.ImportUsers();
            string result = userDatabase.Users[0].ToString();
            // Assert
            Assert.AreEqual(expected, result); ;
        }
        [Test]
        public void ImportUsers_WrongPathSpecified_ErrorThrown()
        {
            // Arrange
            UserDatabase UserDB = CreateUserDatabase();
            UserDB.Path = "/LineSystemExamExercise/ImportFiles\\users.csv";

            // Act
            try
            {
                UserDB.ImportUsers(); ;

            }
            catch (FileNotFoundException)
            {
                Assert.Pass();
                return;
            }
            Assert.Fail();
        }
    }
}

