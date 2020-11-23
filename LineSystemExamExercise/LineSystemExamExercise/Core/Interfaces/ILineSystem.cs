using System;
using System.Collections.Generic;

namespace Core
{
    public interface ILineSystem
    {
        List<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        List<Transaction> GetTransactions(User user, int count);
        List<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
        //event UserBalanceNotification UserBalanceWarning; TODO
    }
}
