using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// linesystem handles the entire backend
    /// </summary>
    public class LineSystem : ILineSystem
    {
        public LineSystem() { }


        #region Properties
        public List<Product> ActiveProducts => CurrentProductCatalog.AllProducts
                                                .FindAll(product => product.IsActive == true)
                                                .OrderBy(product => product.ID)
                                                .ToList();

        public List<Transaction> SuccessfulTransactions { get; set; } = new List<Transaction>();

        public UserDatabase CurrentUserDatabase { get; set; } = new UserDatabase();

        public ProductCatalog CurrentProductCatalog { get; set; } = new ProductCatalog();

        public event EventHandler<User> UserBalanceWarningEvent;

        public event EventHandler<Transaction> TransactionExecutedEvent;
        #endregion


        #region Methods
        /// <summary>
        /// Purchases a product on the users account
        /// </summary>
        /// <param name="user">the user to bill</param>
        /// <param name="product">the product to buy</param>
        /// <returns>the transaction of the purchase</returns>
        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction purchase = new BuyTransaction(user, product);
            ExecuteTransaction(purchase);
            return purchase;
        }

        /// <summary>
        /// Adds an amount to the users balance
        /// </summary>
        /// <param name="user">the user whose balance should be increased</param>
        /// <param name="amount">the amount to add</param>
        /// <returns></returns>
        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction cashInsertion = new InsertCashTransaction(user, amount);
            ExecuteTransaction(cashInsertion);
            return cashInsertion;
        }

        /// <summary>
        /// transaction is excuted and it is added to the succesful actions list.
        /// </summary>
        /// <param name="transaction"></param>
        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            SuccessfulTransactions.Add(transaction);
            TransactionExecutedEvent?.Invoke(this, transaction);
            CheckIfUserBelow50(transaction.User);
        }

        /// <summary>
        /// If user balance is below 50 invokes the UserBalanceWarningEvent
        /// </summary>
        /// <param name="user"></param>
        private void CheckIfUserBelow50(User user)
        {
            if (user.Balance < 50) UserBalanceWarningEvent?.Invoke(this, user);
        }

        /// <summary>
        /// Gets the product defined by the id from the productcatalog
        /// </summary>
        /// <param name="ID">the id of the desired product</param>
        /// <returns></returns>
        public Product GetProductByID(int ID) => CurrentProductCatalog.AllProducts.Find(product => product.ID == ID)
                                                ?? throw new ProductNotFoundException($"The product with ID{ID} does not exist");

        /// <summary>
        /// Finds All users that fulfill the chosen predicate
        /// </summary>
        /// <param name="predicate">the predicate to filter users on</param>
        /// <returns>List of users that fulfill requirement</returns>
        public List<User> GetUsers(Func<User, bool> predicate) => CurrentUserDatabase.Users.FindAll(user => predicate(user));

        /// <summary>
        /// Gets the user with the chosen username
        /// </summary>
        /// <param name="username">the username of the user to find</param>
        /// <returns>The user with the selected username</returns>
        public User GetUserByUsername(string username) => CurrentUserDatabase.Users.Find(user => user.Username == username)
                                                        ?? throw new NoUserFoundException(username);

        /// <summary>
        /// Gets x newest transactions from the selected user, if there is less transactions than amount, returns all
        /// </summary>
        /// <param name="user">the user to find transactions from</param>
        /// <param name="count">amount of transactions to get</param>
        /// <returns>a list of transactions from the user</returns>
        public List<Transaction> GetBuyTransactions(User user, int count = int.MaxValue)
        {
            List<Transaction> usertransactions = SuccessfulTransactions
                                                    .Where(transaction => transaction.User == user && transaction is BuyTransaction)
                                                    .OrderByDescending(transaction => transaction.ID)
                                                    .ToList();
            return count > usertransactions.Count ? usertransactions : usertransactions.GetRange(0, count);
        }
        #endregion
    }
}
