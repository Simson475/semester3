using Core;
using NSubstitute;
using NUnit.Framework;
using System;

namespace LineSystem.UnitTests.Core.Classes
{
    [TestFixture]
    public class SeasonalProductTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private SeasonalProduct CreateSeasonalProduct()
        {
            return new SeasonalProduct();
        }

        [Test]
        public void IsActive_InSeasonAndActive_ActiveIsTrue()
        {
            // Arrange
            SeasonalProduct seasonalProduct = CreateSeasonalProduct();

            seasonalProduct.SeasonStartDate = DateTime.Now.AddDays(-1);
            seasonalProduct.SeasonEndDate = DateTime.Now.AddDays(1);
            seasonalProduct.IsActive = true;
            // Act
            // Assert
            Assert.IsTrue(seasonalProduct.IsActive);
        }
        [Test]
        public void IsActive_OutOfSeasonAndActive_ActiveIsFalse()
        {
            // Arrange
            SeasonalProduct seasonalProduct = CreateSeasonalProduct();

            seasonalProduct.SeasonStartDate = DateTime.Now.AddDays(-2);
            seasonalProduct.SeasonEndDate = DateTime.Now.AddDays(-1);
            seasonalProduct.IsActive = true;
            // Act
            // Assert
            Assert.IsFalse(seasonalProduct.IsActive);
        }

        [Test]
        public void IsActive_InSeasonAndInactive_ActiveIsFalse()
        {
            // Arrange
            SeasonalProduct seasonalProduct = CreateSeasonalProduct();

            seasonalProduct.SeasonStartDate = DateTime.Now.AddDays(-1);
            seasonalProduct.SeasonEndDate = DateTime.Now.AddDays(1);
            seasonalProduct.IsActive = false;
            // Act
            // Assert
            Assert.IsFalse(seasonalProduct.IsActive);
        }
    }
}
