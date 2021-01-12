using System;

namespace Core
{
    /// <summary>
    /// a transaction class other transactions inherit from
    /// </summary>
    public abstract class Transaction
    {
        public Transaction() { }
        public Transaction(User user, decimal amount)
        {
            User = user;
            Amount = amount;
            Date = DateTime.UtcNow;
            ID = GetNextID();

        }

        #region Backing fields
        private User _User;
        private Decimal _Amount;
        #endregion

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

        #region Methods
        /// <summary>
        /// Gets id for transaction creation, ticks nextId up so its ready for next call
        /// </summary>
        /// <returns>the next available id</returns>
        public static int GetNextID() => NextId++;

        /// <summary>
        /// determines how a transaction is executed.
        /// </summary>
        public abstract void Execute();

        public override string ToString() => $"{ID}: Username:{User.Username} Amount:{Amount} Date:{Date:d/M/yyyy}";

        #endregion
    }
}
