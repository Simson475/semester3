using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class LineSystem : ILineSystem//TODO event to show user has too little money on they account
    {
        public LineSystem() { }
        public List<Product> ActiveProducts => CurrentProductCatalog.AllProducts.FindAll(product => product.Active == true);
        public List<Transaction> SuccessfulTransactions { get; set; } = new List<Transaction>();
        public UserDatabase CurrentUserDatabase { get; set; } = new UserDatabase();
        public ProductCatalog CurrentProductCatalog { get; set; } = new ProductCatalog();

        #region methods
        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction purchase = new BuyTransaction(user, product);
            ExecuteTransaction(purchase);//Maybe remove? TODO
            return purchase;

        }

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction cashInsertion = new InsertCashTransaction(user, amount);
            ExecuteTransaction(cashInsertion);//maybe remove? TODO
            return cashInsertion;

        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            SuccessfulTransactions.Add(transaction);
        }

        public Product GetProductByID(int ID) => ActiveProducts.Find(product => product.ID == ID)
                                                ?? throw new ProductNotFoundException($"The product with ID{ID} does not exist");

        public List<User> GetUsers(Func<User, bool> predicate) => CurrentUserDatabase.Users.FindAll(user => predicate(user));

        public User GetUserByUsername(string username) => CurrentUserDatabase.Users.Find(user => user.Username == username);


        public List<Transaction> GetTransactions(User user, int count = int.MaxValue)
        {
            List<Transaction> usertransactions = SuccessfulTransactions.FindAll(transaction => transaction.User == user).OrderBy(transaction => transaction.ID).ToList();
            int elementsToRemove = usertransactions.Count - count;
            for (int i = elementsToRemove; i > 0; i--)
            {
                usertransactions.RemoveAt(0);
            }
            return usertransactions;
        }
        #endregion
    }
}
