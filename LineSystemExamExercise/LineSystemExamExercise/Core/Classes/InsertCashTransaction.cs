namespace Core
{
    /// <summary>
    /// transaction with information about a deposit
    /// </summary>
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount) { }
        public InsertCashTransaction() { }
        public override string ToString() => $"{ID}: {User} Deposited {Amount} at {Date:d/M/yyyy}";

        /// <summary>
        /// Inserts the amount of money to the users account
        /// </summary>
        public override void Execute()
        {
            User.Balance += Amount;
        }
    }
}
