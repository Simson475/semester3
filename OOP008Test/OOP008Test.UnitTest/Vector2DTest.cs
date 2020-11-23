using NUnit.Framework;
using System;
using OOP008Test;

namespace OOP008Test.UnitTest
{
    public class Vector2DTest
    {
        [Test]
        [TestCase(1.5, 1.2)]
        [TestCase(-5, 3)]
        [TestCase(2, -28)]
        public void Constructor_GiveCorrectValues_SetsValuesCorrectlr(double x, double y)
        {
            //Arange
            //Act
            Vector2D actual = new Vector2D(x, y);
            //Assert
            Assert.AreEqual(actual.X, x);
            Assert.AreEqual(actual.Y, y);
        }

        [Test]
        public void Add_AddAVectorToCurrentVector_XIsAddedCorrectly()
        {
            //arrance
            Vector2D expectedVector2D = new Vector2D(4, 6);
            Vector2D firstvector2D = new Vector2D(1, 2);
            Vector2D secondVector2D = new Vector2D(3, 4);
            //act
            firstvector2D.Add(secondVector2D);
            //assert
            Assert.AreEqual(expectedVector2D.X, firstvector2D.X);
        }
        [Test]
        public void Add_AddAVectorToCurrentVector_YIsAddedCorrectly()
        {
            //arrance
            Vector2D expectedVector2D = new Vector2D(4, 6);
            Vector2D firstvector2D = new Vector2D(1, 2);
            Vector2D secondVector2D = new Vector2D(3, 4);
            //act
            firstvector2D.Add(secondVector2D);
            //assert
            Assert.AreEqual(expectedVector2D.Y, firstvector2D.Y);
        }
        public void Subtract_SubtractAVectorToCurrentVector_XIsSubtractedCorrectly()
        {
            //arrance
            Vector2D expectedVector2D = new Vector2D(-2, -2);
            Vector2D firstvector2D = new Vector2D(1, 2);
            Vector2D secondVector2D = new Vector2D(3, 4);
            //act
            firstvector2D.Subtract(secondVector2D);
            //assert
            Assert.AreEqual(expectedVector2D.X, firstvector2D.X);
        }
        [Test]
        public void Subtract_SubtractAVectorToCurrentVector_YIsSubtractedCorrectly()
        {
            //arrance
            Vector2D expectedVector2D = new Vector2D(-2, -2);
            Vector2D firstvector2D = new Vector2D(1, 2);
            Vector2D secondVector2D = new Vector2D(3, 4);
            //act
            firstvector2D.Subtract(secondVector2D);
            //assert
            Assert.AreEqual(expectedVector2D.Y, firstvector2D.Y);
        }

        [Test]
        public void Scalar_CalculateScalarOfTwoVectors_ReturnsCorrectScalar()
        {
            //Arrange
            Vector2D firstvector2D = new Vector2D(1, 2);
            Vector2D secondVector2D = new Vector2D(3, 4);
            double expected = firstvector2D.X * secondVector2D.X + firstvector2D.Y * secondVector2D.Y;
            //Act
            double actual = firstvector2D.Scalar(secondVector2D);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CrossProduct_CalculateCrossProductOfTwoVectors_ReturnsCorrectCrossProduct()
        {
            //Arrange
            Vector2D firstvector2D = new Vector2D(1, 2);
            Vector2D secondVector2D = new Vector2D(3, 4);
            double expected = firstvector2D.X * secondVector2D.Y + firstvector2D.Y * secondVector2D.X;
            //Act
            double actual = firstvector2D.CrossProduct(secondVector2D);
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}