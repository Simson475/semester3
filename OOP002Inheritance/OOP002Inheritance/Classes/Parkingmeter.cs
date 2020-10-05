using System;

namespace OOP002Inheritance
{
    class ParkingMeter
    {
        public ParkingMeter() { }
        public ParkingMeter(double payment)
        {
            Pay(payment);
        }
        public DateTime PaidUntill { get; private set; } = DateTime.Now;
        public void Pay(double payment)
        {
            DayOfWeek DayOfWeek = DateTime.Now.DayOfWeek;

            switch (DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    if (PaidUntill < DateTime.Now) PaidUntill = DateTime.Now;
                    WeekendParkingRate WeekendRate = new WeekendParkingRate();
                    PaidUntill = PaidUntill.AddMinutes(WeekendRate.ComputeParkingRate(payment));

                    break;
                default:
                    if (PaidUntill < DateTime.Now) PaidUntill = DateTime.Now;
                    WeekdayParkingRate WeekdayRate = new WeekdayParkingRate();
                    PaidUntill = PaidUntill.AddMinutes(WeekdayRate.ComputeParkingRate(payment)); break;
            }
            Console.WriteLine($"You can now park untill {PaidUntill}");
        }
    }
}

