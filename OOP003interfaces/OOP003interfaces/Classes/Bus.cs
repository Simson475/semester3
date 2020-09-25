namespace OOP003interfaces
{
    public class Bus : Vehicle, ITaxable
    {

        protected int numberOfSeats;

        public Bus(int numberOfSeats, int regNumber, decimal value) :
            base(regNumber, 80, value)
        {
            this.numberOfSeats = numberOfSeats;
        }

        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
        }

        decimal ITaxable.TaxValue() => value * 0.25m;

    }
}
