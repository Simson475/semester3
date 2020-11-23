using NUnit.Framework;
using NSubstitute;

namespace OOP008Test.UnitTest
{
    public class CircleTests
    {
        [Test]
        [TestCase(1, 1, 10)]
        [TestCase(-5, 3, 4)]
        [TestCase(2, -28, 7)]
        public void Constructor_GiveCorrectCoordinates_SetsCoordinatesCorrectly(double x, double y, double radius)
        {
            //arange
            var coordinates = Substitute.For<Vector2D>(x, y);

            //act
            Circle actualCircle = new Circle(coordinates, radius);

            //assert
            Assert.AreEqual(actualCircle.Coordinate, coordinates);
        }


        [Test]
        [TestCase(1, 1, 10)]
        [TestCase(-5, 3, 4)]
        [TestCase(2, -28, 7)]
        public void Constructor_GiveCorrectRadius_SetsRadiusCorrectly(double x, double y, double radius)
        {
            //arange
            var coordinates = Substitute.For<Vector2D>(x, y);

            //act
            Circle actualCircle = new Circle(coordinates, radius);

            //assert
            Assert.AreEqual(actualCircle.Radius, radius);
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1)]
        [TestCase(15, 5, 5, 5, 10)]
        [TestCase(1, 1, 1, 1, 0.001)]
        public void IsInsideCicle_GiveCoordinatesInsideCircle_ReturnsTrue(double coordinateX, double coordinateY, double circleX, double circleY, double radius)
        {
            //Arrange
            bool expected = true;
            var coordinate = Substitute.For<Vector2D>(coordinateX, coordinateY);
            var circleCoordinate = Substitute.For<Vector2D>(circleX, circleY);

            //Act
            Circle circle = new Circle(circleCoordinate, radius);
            bool actual = circle.IsInsideCircle(coordinate);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(10, 10, 1, 1, 1)]
        public void IsInsideCicle_GiveCoordinatesOutsideCircle_ReturnsFalse(double coordinateX, double coordinateY, double circleX, double circleY, double radius)
        {
            //Arrange
            bool expected = false;
            var coordinate = Substitute.For<Vector2D>(coordinateX, coordinateY);
            var circleCoordinate = Substitute.For<Vector2D>(circleX, circleY);

            //Act
            Circle circle = new Circle(circleCoordinate, radius);
            bool actual = circle.IsInsideCircle(coordinate);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}