namespace Core
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
            Product = product;
        }
        public BuyTransaction() { }
        public Product Product { get; set; }

        public override string ToString() => $"{ID}: {User} Bought {Product.Name} for {Amount} at {Date:d/M/yyyy}";

        public override void Execute()
        {
            if (User.Balance < Amount) throw new InsufficientCreditsException("Insufficient Credits for purchase!");
            if (Product.Active == false) throw new InactiveProductException($"{Product.Name} is unavailable, you have not been billed.");
            User.Balance -= Amount;
        }
    }
}
