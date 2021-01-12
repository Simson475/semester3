using Core;
using NSubstitute;
using NUnit.Framework;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class LineSystemBuilderTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private LineSystemBuilder CreateLineSystemBuilder()
        {
            return new LineSystemBuilder();
        }

        [Test]
        public void Build_BuildLineSystem_ActiveProductsCanBefoundUnderLineSystem()
        {
            // Arrange
            var lineSystemBuilder = CreateLineSystemBuilder();

            // Act
            LineSystem result = lineSystemBuilder.Build();

            // Assert
            Assert.AreEqual(1, result.ActiveProducts.Count);
        }

        [Test]
        public void Build_BuildLineSystem_UsersCanBefoundImportedAndAddedCorrectly()
        {
            // Arrange
            var lineSystemBuilder = CreateLineSystemBuilder();

            // Act
            LineSystem result = lineSystemBuilder.Build();

            // Assert
            Assert.AreEqual(1, result.CurrentUserDatabase.Users.Count);
        }
    }
}
