namespace OOP002Inheritance
{
    abstract class Parkingmeter
    {
        public abstract double Rate { get; }
        public double MinutesBought { get; set; }
        public void Pay(double payment)
        {
            MinutesBought = payment / Rate;
        }

    }
}
