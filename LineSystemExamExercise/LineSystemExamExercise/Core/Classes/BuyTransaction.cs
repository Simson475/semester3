namespace Core
{
    /// <summary>
    /// Transaction with information about a purchase
    /// </summary>
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
            Product = product;
        }
        public BuyTransaction() { }
        public Product Product { get; set; }

        public override string ToString() => $"{ID}: {User} Bought {Product.Name} for {Amount} at {Date:d/M/yyyy}";

        /// <summary>
        /// sees if the transaction is possible, and if it is, runs the transaction
        /// </summary>
        public override void Execute()
        {
            if (User.Balance < Amount && Product.CanBeBoughtOnCredit == false) throw new InsufficientCreditsException("Insufficient Credits for purchase!", User, Product);
            if (Product.IsActive == false) throw new InactiveProductException($"{Product.Name} is unavailable");
            User.Balance -= Amount;
        }
    }
}
