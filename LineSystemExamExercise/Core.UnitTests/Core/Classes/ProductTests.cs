using Core;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class ProductTests
    {
        private Product CreateProduct()
        {
            return new Product(1, "test", 100m, true);
        }

        [Test]
        public void ToString_PrintString_CorrectString()
        {
            // Arrange
            Product product = CreateProduct();
            string expected = "1: test, 100.-";
            // Act
            string result = product.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Name_NameSetToNull_ErrorIsThrown()
        {
            // Arrange
            Product product = CreateProduct();
            // Act
            try
            {
                product.Name = null;
            }
            catch (ArgumentNullException)
            {
                // Assert
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void Price_PriceBelow0_ErrorIsThrown()
        {
            // Arrange
            Product product = CreateProduct();
            // Act
            try
            {
                product.Price = -10;
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }
    }
}
