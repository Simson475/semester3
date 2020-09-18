using System;

namespace OOP002Inheritance
{
    class BankAccount
    {
        private decimal _Balance = 0m;
        private decimal _BorrowingRate = 1.1m;
        private decimal _SavingsRate = 1.01m;
        public decimal Balance
        {
            get
            {
                return _Balance;
            }
            private set
            {
                try
                {
                    if (value > 250000m) throw new ArgumentException("Cannot deposit since balance will be above 250.000");
                    if (value < -100000m) throw new ArgumentException("Cannot withdraw since balance will be below -100.000");
                    _Balance = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }
        public decimal BorrowingRate
        {
            get
            {
                return _BorrowingRate;
            }
            private set
            {
                try
                {
                    if (value <= 1.06m) throw new ArgumentException("Borrowing rate cannot be set below 6% (1.06)");
                    _BorrowingRate = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public decimal SavingsRate
        {
            get
            {
                return _SavingsRate;
            }
            private set
            {
                try
                {
                    if (value >= 1.02m) throw new ArgumentException("Savings rate cannot be set above 2% (1.02)");
                    _SavingsRate = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public void Deposit(decimal amount)
        {
            try
            {
                if (amount < 0) throw new Exception("Cannot deposit less than 0");
                Balance += amount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Withdraw(decimal amount)
        {
            try
            {
                if (amount < 0) throw new Exception("Cannot deposit less than 0");
                Balance -= amount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Interest()
        {
            if (Balance < 0)
            {
                Balance *= SavingsRate;
            }
            else
            {
                Balance *= BorrowingRate;
            }
        }
    }
}
