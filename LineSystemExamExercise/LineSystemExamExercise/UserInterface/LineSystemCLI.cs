using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public class LineSystemCLI : ILineSystemUI
    {
        public LineSystemCLI(LineSystem linesystem)
        {
            InternalLineSystem = linesystem;
            linesystem.UserBalanceWarningEvent += DisplayUserBalanceWarning;

        }


        #region properties
        public bool IsRunning { get; set; }
        public ILineSystem InternalLineSystem { get; set; }
        public event EventHandler<string> CommandEntered;
        private Action DisplayMessageDelegate { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Adds a user balance warning to the print delegate
        /// </summary>
        /// <param name="sender">class that invoked the event</param>
        /// <param name="user">the user with low balance</param>
        private void DisplayUserBalanceWarning(object sender, User user)
        {
            string message = $"{user.Username} has low balance! the balance is {user.Balance}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// Launches the user interface
        /// </summary>
        public void Start()
        {
            IsRunning = true;
            Console.WriteLine("To purchase a product write your username and ProductID");
            Console.WriteLine("To purchase multiple of the same product, write username, amount and productid");
            Console.WriteLine("To get user information, write username");
            do
            {
                PrintProductsToScreen();
                string input = Console.ReadLine();
                Console.Clear();
                HandleInput(input);
            } while (IsRunning == true);

        }

        /// <summary>
        /// Takes the users input and invokes an event with it, it then writes all display messages to screen and resets list
        /// </summary>
        /// <param name="input">input taken from user</param>
        private void HandleInput(string input)
        {
            CommandEntered?.Invoke(this, input);
            DisplayMessageDelegate?.Invoke();
            Console.WriteLine("\n");
            DisplayMessageDelegate = null;
        }

        /// <summary>
        /// Prints all active products to screen
        /// </summary>
        private void PrintProductsToScreen()
        {
            List<Product> products = InternalLineSystem.ActiveProducts;

            //Calculate biggest sizes needed for elements
            int biggestNameLength = 0;
            int biggestIDSize = 0;
            int biggestPriceSize = 0;
            foreach (var item in products)
            {
                if (item.Name.Length > biggestNameLength) biggestNameLength = item.Name.Length;
                if (item.ID.ToString().Length > biggestIDSize) biggestIDSize = item.ID.ToString().Length;
                if (item.Price.ToString().Length > biggestPriceSize) biggestPriceSize = item.Price.ToString().Length;
            }

            //Write header
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("|");
            for (int i = 0; i < biggestIDSize - 2; i++) Console.Write(" ");
            Console.Write($"ID|");

            for (int i = 0; i < (biggestNameLength - 4) / 2; i++) Console.Write(" ");
            Console.Write("Name");
            for (int i = 0; i < (biggestNameLength - 4 + 1) / 2; i++) Console.Write(" ");

            Console.Write($"|Price");
            for (int i = 0; i < biggestPriceSize - 2; i++) Console.Write(" ");
            Console.Write("|");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");


            //Print Each Product
            foreach (Product product in products)
            {
                int IDLength = product.ID.ToString().Length;
                int nameLength = product.Name.Length;
                int priceLength = product.Price.ToString().Length;

                Console.Write("|");

                for (int i = 0; i < biggestIDSize - IDLength; i++) Console.Write(" ");

                Console.Write($"{product.ID}|");

                for (int i = 0; i < (biggestNameLength - nameLength) / 2; i++) Console.Write(" ");

                Console.Write(product.Name);

                for (int i = 0; i < (biggestNameLength - nameLength + 1) / 2; i++) Console.Write(" ");

                Console.Write($"| {product.Price},-");

                for (int i = 0; i < biggestPriceSize - priceLength; i++) Console.Write(" ");

                Console.WriteLine("|");
            }
        }

        /// <summary>
        /// Closes the user interface
        /// </summary>
        public void Close() => IsRunning = false;


        /// <summary>
        /// adds a warning that admincommand was not found to the displayMessageDelegate
        /// </summary>
        /// <param name="adminCommand">The command that was not found</param>
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            string message = $"The Command was not a valid admin command!\nThe command was: {adminCommand}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// A generalized error with the inputted string is added to the display message delegate
        /// </summary>
        /// <param name="errorString">error message to show user</param>
        public void DisplayGeneralError(string errorString)
        {
            string message = $"An error ocurred!\nError message: {errorString}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// adds an insufficient cash message to the displayMessageDelegate
        /// </summary>
        /// <param name="user">the user with too few credits</param>
        /// <param name="product">the product that the user cannot afford</param>
        public void DisplayInsufficientCash(User user, Product product) => DisplayInsufficientCash(user, product, 1);

        /// <summary>
        /// adds an insufficient cash message to the displayMessageDelegate
        /// </summary>
        /// <param name="user">the user with too few credits</param>
        /// <param name="product">the product that the user cannot afford</param>
        /// <param name="amount">how many of the product the user wanted</param>
        public void DisplayInsufficientCash(User user, Product product, int amount)
        {
            string message = $"{user.Username} has insufficient credits on their acocunt, they have {user.Balance},- and {product.Price * amount},- is needed to buy {amount} {product.Name}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// adds an Product not found message to the displayMessageDelegate
        /// </summary>
        /// <param name="id">id of the nonexisting product</param>
        public void DisplayProductNotFound(string id)
        {
            string message = $"Product with the ID {id} was not found";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// adds a  message to the displayMessageDelegate the message says that the system received too many arguments
        /// </summary>
        /// <param name="command">the command that triggered the message</param>
        public void DisplayTooManyArgumentsError(string command)
        {
            string message = $"Too many arguments!\nThe command was: {command}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// adds a  message to the displayMessageDelegate the message says that the purchase went through
        /// </summary>
        /// <param name="transaction">the purchase transaction</param>
        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            string message = transaction.ToString();
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// adds a  message to the displayMessageDelegate the message says that the purchase of several products went through
        /// </summary>
        /// <param name="count">how many transactions were made</param>
        /// <param name="transaction">one of the transactions</param>
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            string message = $"{transaction.User.Username} Bought {count} {transaction.Product.Name} for {transaction.Amount * count} at {transaction.Date:d/M/yyyy}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// adds a  message to the displayMessageDelegate the message says that the user could not be found
        /// </summary>
        /// <param name="username">the username with no user attached</param>
        public void DisplayUserNotFound(string username)
        {
            string message = $"No user found with the username {username}";
            DisplayMessageDelegate += () => Console.WriteLine(message);
        }

        /// <summary>
        /// Writes detailed user info to the screen.
        /// </summary>
        /// <param name="user">the user to print info about</param>
        public void DisplayUserInfo(User user)
        {
            Console.WriteLine("UserInfo:");
            Console.WriteLine($"Username: {user.Username} Name: {user.FullName} Balance:{user.Balance}");
            List<Transaction> transactions = InternalLineSystem.GetBuyTransactions(user, 10);
            foreach (var item in transactions)
            {
                Console.WriteLine(item);
            }
            if (user.Balance < 50)
            {
                Console.WriteLine("YOUR BALANCE IS UNDER 50!");
            }
            Console.WriteLine("Press enter to continue");
            _ = Console.ReadLine();
            Console.Clear();
        }
    }
    #endregion
}
