namespace OOP002Inheritance
{
    class WeekendParkingRate : ParkingRate
    {
        public override double ComputeParkingRate(double payment)
        {
            return payment / 25;
        }
    }
}

