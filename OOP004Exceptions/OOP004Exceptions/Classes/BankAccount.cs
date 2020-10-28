using System;

namespace OOP004Exceptions
{
    class BankAccount
    {
        public BankAccount() { }
        public BankAccount(decimal depositAmount)
        {
            Deposit(depositAmount);
        }
        private decimal _Balance;
        public decimal Balance
        {
            get => _Balance;
            private set
            {
                if (value <= 0) throw new InsufficientFundsException();
                _Balance = value;
            }
        }
        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                Balance += amount;
            }
            else throw new Exception("Cannot deposit less than 0");
        }
        public void Withdraw(decimal amount)
        {
            if (amount >= 0)
            {
                Balance -= amount;
            }
            else throw new Exception("Cannot Withdraw less than 0");

        }
    }
}
