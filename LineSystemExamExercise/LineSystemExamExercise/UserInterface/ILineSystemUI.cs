using Core;
using System;

namespace UserInterface
{
    public interface ILineSystemUI
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string product);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user, Product product);
        void DisplayInsufficientCash(User user, Product product, int amount);
        void DisplayGeneralError(string errorString);
        void Start();
        event EventHandler<string> CommandEntered;
    }
}
