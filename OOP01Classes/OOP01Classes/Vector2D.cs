namespace OOP01Classes
{
    public class Vector2D
    {
        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator *(Vector2D v1, double Multiplier)
        {
            return new Vector2D(v1.x * Multiplier, v1.y * Multiplier);
        }

        public double x { get; set; }
        public double y { get; set; }
    }
}
