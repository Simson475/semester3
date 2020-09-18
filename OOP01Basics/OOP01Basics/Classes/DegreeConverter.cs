using System;

namespace OOP01
{
    public static class DegreeConverter
    {
        public static double ToRadians(double degrees)
        {
            return (degrees % 360) * (Math.PI / 180);
        }
        public static double ToDegrees(double radians)
        {
            return radians % (2 * Math.PI) * (180 / Math.PI);
        }
    }
}
