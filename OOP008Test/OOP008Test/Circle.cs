using System;

namespace OOP008Test
{
    public class Circle
    {
        public Circle(Vector2D coordinate, double radius)
        {
            Coordinate = coordinate;
            Radius = radius;
        }
        public Vector2D Coordinate { get; set; }
        public double Radius { get; set; }

        public bool IsInsideCircle(Vector2D coordinate)
        {
            return Math.Sqrt(Math.Pow(Coordinate.X - coordinate.Y, 2) + Math.Pow(Coordinate.Y - coordinate.Y, 2)) <= Radius;
        }
    }

}
