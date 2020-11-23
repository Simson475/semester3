using Core;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class ProductCatalogTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private ProductCatalog CreateProductCatalog()
        {
            return new ProductCatalog();
        }

        [Test]
        public void ImportCSVfile_ImportFile_ImportedCorrectly()
        {
            // Arrange
            ProductCatalog productCatalog = CreateProductCatalog();
            productCatalog.Path = "../../../../LineSystemExamExercise/ImportFiles\\products.csv";

            // Act
            productCatalog.ImportCSVfile();
            Product result = productCatalog.AllProducts[0];
            // Assert
            Assert.AreEqual("1: Diverse, 1.-", result.ToString());
        }
        [Test]
        public void ImportCSVfile_WrongPathSpecified_ErrorThrown()
        {
            // Arrange
            ProductCatalog productCatalog = CreateProductCatalog();
            productCatalog.Path = "/LineSystemExamExercise/ImportFiles\\products.csv";

            // Act
            try
            {
                productCatalog.ImportCSVfile();

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
