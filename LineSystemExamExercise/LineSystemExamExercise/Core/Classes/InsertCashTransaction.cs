namespace Core
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount) { }
        public InsertCashTransaction() { }
        public override string ToString() => $"{ID}: {User} Deposited {Amount} at {Date:d/M/yyyy}";

        public override void Execute()
        {
            User.Balance += Amount;
        }
    }
}
