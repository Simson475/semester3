namespace OOP002Inheritance
{
    class WeekdayParkingRate : ParkingRate
    {
        public override double ComputeParkingRate(double payment)
        {
            return payment / 20;
        }
    }
}

