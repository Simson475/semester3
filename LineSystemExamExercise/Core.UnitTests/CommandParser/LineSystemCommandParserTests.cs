using CommandParser;
using NSubstitute;
using NUnit.Framework;
using UserInterface;



namespace Core.UnitTests.CommandParser
{
    [TestFixture]
    public class LineSystemCommandParserTests
    {
        private ILineSystemUI subLineSystemUI;
        private LineSystem subLineSystem;

        [SetUp]
        public void SetUp()
        {
            subLineSystemUI = Substitute.For<ILineSystemUI>();
            subLineSystem = Substitute.For<LineSystem>();
        }

        private LineSystemCommandParser CreateLineSystemCommandParser()
        {
            return new LineSystemCommandParser(
                subLineSystemUI,
                subLineSystem);
        }

        [Test]
        public void ParseCommand_ActivateProduct_ProductIsActive()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":activate 10";
            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 10;
            subProduct.IsActive = false;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.IsTrue(subProduct.IsActive);
        }

        [Test]
        public void ParseCommand_ActivateProductWithExtraWords_InvalidCommand()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":activate 10 asdjkladf";
            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 10;
            subProduct.IsActive = false;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayAdminCommandNotFoundMessage(command);
        }

        [Test]
        public void ParseCommand_DeactivateProduct_ProductIsInactive()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":deactivate 10";
            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 10;
            subProduct.IsActive = true;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.IsFalse(subProduct.IsActive);
        }

        [Test]
        public void ParseCommand_QuitUI_UICloseMethodIsCalled()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":q";


            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().Close();
        }

        [Test]
        public void ParseCommand_CreditOn_ProductCanBeBoughtOnCredit()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":crediton 10";
            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 10;
            subProduct.CanBeBoughtOnCredit = false;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.IsTrue(subProduct.CanBeBoughtOnCredit);
        }

        [Test]
        public void ParseCommand_CreditOff_ProductCanBeBoughtOnCredit()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":creditoff 10";
            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 10;
            subProduct.CanBeBoughtOnCredit = true;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.IsFalse(subProduct.CanBeBoughtOnCredit);
        }

        [Test]
        public void ParseCommand_AddCredit_CreditsAreAdded()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            decimal expected = 10m;
            string command = ":addcredits test 10";
            User subUser = Substitute.For<User>();
            subUser.Username = "test";
            subUser.Balance = 0m;
            subLineSystem.CurrentUserDatabase.Users.Add(subUser);

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.AreEqual(expected, subUser.Balance);
        }

        [Test]
        public void ParseCommand_WriteOnlyUsername_GetUserByUsernameIsCalled()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = "test";
            User subUser = Substitute.For<User>();
            subUser.Username = "test";
            subLineSystem.CurrentUserDatabase.Users.Add(subUser);

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayUserInfo(subUser);
        }

        [Test]
        public void ParseCommand_WriteOnlyUsernameInvalidUser_NoUserFoundCalled()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = "test";

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayUserNotFound(command);
        }

        [Test]
        public void ParseCommand_PurchaseProduct_ProductIsPurchased()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = "test 10";

            User subUser = Substitute.For<User>();
            subUser.Username = "test";
            subLineSystem.CurrentUserDatabase.Users.Add(subUser);
            subUser.Balance = 10;

            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 10;
            subProduct.Price = 10;
            subProduct.IsActive = true;
            decimal expected = 0;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.AreEqual(expected, subUser.Balance);
        }



        [Test]
        public void ParseCommand_Purchase10Product_ProductIsPurchased()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = "test 10 11";

            User subUser = Substitute.For<User>();
            subUser.Username = "test";
            subLineSystem.CurrentUserDatabase.Users.Add(subUser);
            subUser.Balance = 100;

            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 11;
            subProduct.Price = 10;
            subProduct.IsActive = true;
            decimal expected = 0;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            Assert.AreEqual(expected, subUser.Balance);
        }

        [Test]
        public void ParseCommand_Purchase10Product_NotEnoughtCredits()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = "test 10 11";

            User subUser = Substitute.For<User>();
            subUser.Username = "test";
            subLineSystem.CurrentUserDatabase.Users.Add(subUser);
            subUser.Balance = 10;

            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 11;
            subProduct.Price = 10;
            subProduct.CanBeBoughtOnCredit = false;
            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayInsufficientCash(subUser, subProduct, 10);
        }

        [Test]
        public void ParseCommand_PurchasenNegativeAmountOfProduct_ErrorIsDisplayed()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = "test -10 11";

            User subUser = Substitute.For<User>();
            subUser.Username = "test";
            subLineSystem.CurrentUserDatabase.Users.Add(subUser);
            subUser.Balance = 100;

            Product subProduct = Substitute.For<Product>();
            subLineSystem.CurrentProductCatalog.AllProducts.Add(subProduct);
            subProduct.ID = 11;
            subProduct.Price = 10;
            subProduct.IsActive = true;

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayGeneralError("Amount cannot be negative");
        }

        [Test]
        public void ParseCommand_CommandIsEmpty_DisplayError()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = " ";

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayGeneralError("An empty command does nothing");
        }

        [Test]
        public void ParseCommand_FakeAdminCommand_DisplayError()
        {
            // Arrange
            var lineSystemCommandParser = CreateLineSystemCommandParser();
            object sender = null;
            string command = ":ahsdjk";

            // Act
            lineSystemCommandParser.ParseCommand(
                sender,
                command);

            // Assert
            subLineSystemUI.Received().DisplayAdminCommandNotFoundMessage(command);
        }
    }
}
