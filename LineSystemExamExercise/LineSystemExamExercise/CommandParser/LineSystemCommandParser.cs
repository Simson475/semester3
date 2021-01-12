using Core;
using System;
using System.Collections.Generic;
using UserInterface;

namespace CommandParser
{
    /// <summary>
    /// Signs up to an event from the UI and parses the information, changing the line system according, and telling the UI what to show.
    /// </summary>
    public class LineSystemCommandParser
    {
        public LineSystemCommandParser(ILineSystemUI ui, ILineSystem linesystem)
        {
            UI = ui;
            UI.CommandEntered += ParseCommand;
            CoreLineSystem = linesystem;
            AdminCommands = new Dictionary<string, Action<string>>()
            {
                {":quit",command=>Close() },
                {":q",command=>Close() },
                {":activate",command=>ChangeActivationState(command, true) },
                {":deactivate",command=>ChangeActivationState(command, false) },
                {":crediton",command=>ChangeCreditState(command, true) },
                {":creditoff",command=>ChangeCreditState(command, false) },
                {":addcredits",command=>AddCredits(command) }
            };
        }

        #region properties
        public ILineSystemUI UI { get; set; }
        public ILineSystem CoreLineSystem { get; set; }
        public Dictionary<string, Action<string>> AdminCommands { get; }
        #endregion

        #region methods
        /// <summary>
        /// Is called through an event in the user interface. it takes a command, parses it and calls the appropriate function in the system.
        /// </summary>
        /// <param name="sender">the class that invoked the event</param>
        /// <param name="command">the command to parse and act on</param>
        public void ParseCommand(object sender, string command)
        {
            string[] splitCommand = command.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //check if command is empty
            if (splitCommand.Length == 0 || String.IsNullOrEmpty(splitCommand[0])) UI.DisplayGeneralError("An empty command does nothing");
            //Check if command is admin command
            else if (command.StartsWith(":")) AdminCommand(command, splitCommand);
            //Check if length fits with userinfo
            else if (splitCommand.Length == 1) UserInfoCommand(splitCommand);
            //Check if length fits purchase
            else if (splitCommand.Length == 2) PurchaseCommand(splitCommand);
            //Check if length fits multipurchase
            else if (splitCommand.Length == 3) MultiPurchaseCommand(splitCommand);
            else UI.DisplayTooManyArgumentsError(command);
        }

        /// <summary>
        /// Parses the command and purchases an amount of a chosen product 
        /// </summary>
        /// <param name="splitCommand">the command split into different strings. first argument is username, second is amount and third is the productID</param>
        private void MultiPurchaseCommand(string[] splitCommand)
        {
            try
            {
                //parse int
                int amount = int.Parse(splitCommand[1]);
                int productID = int.Parse(splitCommand[2]);
                //get needed data from core
                User user = CoreLineSystem.GetUserByUsername(splitCommand[0]);
                Product product = CoreLineSystem.GetProductByID(productID);

                //make sure they can afford and not buying negative amount
                if (amount <= 0) UI.DisplayGeneralError("Amount cannot be negative");
                else if (user.Balance < product.Price * amount && product.CanBeBoughtOnCredit == false) UI.DisplayInsufficientCash(user, product, amount);
                else
                {
                    //purchase
                    List<BuyTransaction> purchases = new List<BuyTransaction>();
                    for (int i = 0; i < amount; i++) purchases.Add(CoreLineSystem.BuyProduct(user, product));
                    UI.DisplayUserBuysProduct(amount, purchases[0]);
                }
            }
            catch (NoUserFoundException e)
            {
                UI.DisplayUserNotFound(e.Message);
            }
            catch (ProductNotFoundException)
            {
                UI.DisplayProductNotFound(splitCommand[2]);
            }
            catch (FormatException)
            {
                UI.DisplayGeneralError("Purchase amount and productID must be an integer");
            }

        }

        /// <summary>
        /// Purchases a single product for the user
        /// </summary>
        /// <param name="splitCommand">the command split up, first parameter is username, second is productID</param>
        private void PurchaseCommand(string[] splitCommand)
        {
            try
            {
                //get info needed for purchase
                User user = CoreLineSystem.GetUserByUsername(splitCommand[0]);
                int productID = int.Parse(splitCommand[1]);
                Product product = CoreLineSystem.GetProductByID(productID);

                //Purchase
                BuyTransaction purchase = CoreLineSystem.BuyProduct(user, product);

                //If no errors
                UI.DisplayUserBuysProduct(purchase);
            }
            catch (NoUserFoundException e)
            {
                UI.DisplayUserNotFound(e.Message);
            }
            catch (ProductNotFoundException)
            {
                UI.DisplayProductNotFound(splitCommand[1]);
            }
            catch (InsufficientCreditsException e)
            {
                UI.DisplayInsufficientCash(e.User, e.Product);
            }
            catch (FormatException)
            {
                UI.DisplayGeneralError("ProductID must be an integer");
            }
        }

        /// <summary>
        /// called when an admin command is called, identifies which command it is, and calls the appropriate function
        /// </summary>
        /// <param name="command">the command received</param>
        /// <param name="splitCommand">the command split into an array</param>
        private void AdminCommand(string command, string[] splitCommand)
        {
            if (AdminCommands.TryGetValue(splitCommand[0], out Action<string> inputCommand)) inputCommand(command);
            else UI.DisplayAdminCommandNotFoundMessage(command);
        }

        /// <summary>
        /// Finds a user and tells the UI to print the user if it ecists
        /// </summary>
        /// <param name="splitCommand">the command split into array. should only have one element, the username</param>
        private void UserInfoCommand(string[] splitCommand)
        {
            try
            {
                User user = CoreLineSystem.GetUserByUsername(splitCommand[0]);
                UI.DisplayUserInfo(user);
            }
            catch (NoUserFoundException e)
            {
                UI.DisplayUserNotFound(e.Message);
            }
        }

        /// <summary>
        /// closes the UI
        /// </summary>
        private void Close() => UI.Close();

        /// <summary>
        /// Activates or deactivates a product
        /// </summary>
        /// <param name="command">The command that tells what product to (de)activate</param>
        /// <param name="active">determines whether the product is to be activated or deavtivated</param>
        private void ChangeActivationState(string command, bool active)
        {
            string[] splitCommand = command.Split(" ");

            if (splitCommand.Length != 2)
            {
                UI.DisplayAdminCommandNotFoundMessage(command);
                return;
            }

            try
            {
                int id = int.Parse(splitCommand[1]);
                Product product = CoreLineSystem.GetProductByID(id);
                product.IsActive = active;
            }
            catch (ProductNotFoundException)
            {
                UI.DisplayProductNotFound(splitCommand[1]);
            }
            catch (FormatException)
            {
                UI.DisplayGeneralError("ProductID must be an integer");
            }
        }

        /// <summary>
        /// changes the property can be bought on credit on a product defined by the command
        /// </summary>
        /// <param name="command">command defines what product to change the state of</param>
        /// <param name="creditState">what to change the state to (true/false)</param>
        private void ChangeCreditState(string command, bool creditState)
        {
            string[] splitCommand = command.Split(" ");

            if (splitCommand.Length != 2)
            {
                UI.DisplayAdminCommandNotFoundMessage(command);
                return;
            }

            try
            {
                int id = int.Parse(splitCommand[1]);
                Product product = CoreLineSystem.GetProductByID(id);
                if (product is SeasonalProduct) return;
                product.CanBeBoughtOnCredit = creditState;
            }
            catch (ProductNotFoundException)
            {
                UI.DisplayProductNotFound(splitCommand[1]);
            }
            catch (FormatException)
            {
                UI.DisplayGeneralError("ProductID must be an integer");
            }
        }

        /// <summary>
        /// Adds credit to a users account the amount and to what user is specified in command
        /// </summary>
        /// <param name="command">defines what user to add credits to and how many to add</param>
        private void AddCredits(string command)
        {
            string[] splitCommand = command.Split(" ");

            if (splitCommand.Length != 3)
            {
                UI.DisplayAdminCommandNotFoundMessage(command);
                return;
            }

            try
            {
                User user = CoreLineSystem.GetUserByUsername(splitCommand[1]);
                int amount = int.Parse(splitCommand[2]);
                CoreLineSystem.AddCreditsToAccount(user, amount);

            }
            catch (NoUserFoundException e)
            {
                UI.DisplayUserNotFound(e.Message);
            }
            catch (FormatException)
            {
                UI.DisplayGeneralError("UserID must be an integer");
            }

        }
    }
    #endregion
}
