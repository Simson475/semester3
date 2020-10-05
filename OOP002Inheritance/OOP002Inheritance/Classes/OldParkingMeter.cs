namespace OOP002Inheritance
{
    abstract class OldParkingMeter
    {
        public abstract double Rate { get; }
        public double MinutesBought { get; set; }
        public void Pay(double payment)
        {
            MinutesBought = payment / Rate;
        }

    }
}
