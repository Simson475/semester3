using System;

namespace Core
{
    public abstract class Transaction
    {
        public Transaction() { }
        public Transaction(User user, decimal amount)
        {
            User = user;
            Amount = amount;
            ID = GetNextID();
            Date = DateTime.UtcNow;
        }
        private User _User;
        private Decimal _Amount;

        #region Properties
        public static int NextId { get; set; } = 1;
        public int ID { get; }
        public User User
        {
            get { return _User; }
            set { _User = value ?? throw new ArgumentNullException("User cannot be null"); }
        }

        public DateTime Date { get; set; }

        public Decimal Amount
        {
            get { return _Amount; }
            set
            {
                if (value < 0) throw new ArgumentException("Amount cannot be negative");
                else _Amount = value;
            }
        }

        #endregion
        public static int GetNextID() => NextId++;

        public abstract void Execute();
    }
}
