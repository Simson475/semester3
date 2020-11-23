namespace OOP008Test
{
    public class Vector2D
    {
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        public void Add(Vector2D newVector)
        {

            X += newVector.X;
            Y += newVector.Y;
        }
        public void Subtract(Vector2D newVector)
        {

            X -= newVector.X;
            Y -= newVector.Y;
        }

        public double Scalar(Vector2D secondVector)
        {
            return X * secondVector.X + Y * secondVector.Y;
        }
        public double CrossProduct(Vector2D secondVector)
        {
            return X * secondVector.Y + Y * secondVector.X;
        }
    }
}
