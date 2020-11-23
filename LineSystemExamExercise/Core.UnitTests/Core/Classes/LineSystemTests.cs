using Core;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class LineSystemTests
    {

        private User subUser;
        private Product subProduct;

        [SetUp]
        public void SetUp()
        {
            subUser = Substitute.For<User>();
            subProduct = Substitute.For<Product>();
            subProduct.Active = true;
            subProduct.Price = 100m;
            subProduct.Name = "prod";
            subProduct.ID = 1;
            subUser.FirstName = "f";
            subUser.LastName = "l";
            subUser.Email = "t@t.dk";
            subUser.Username = "zelda";
            subUser.Balance = 1000m;
            Transaction.NextId = 1;

        }

        private LineSystem CreateLineSystem()
        {
            return new LineSystem();
        }

        [Test]
        public void BuyProduct_PurchaseProduct_AddedToSuccesfulTransactions()
        {
            // Arrange
            LineSystem lineSystem = CreateLineSystem();
            int expected = 1;
            // Act
            lineSystem.BuyProduct(
                subUser,
                subProduct);
            int result = lineSystem.SuccessfulTransactions.Count;
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddCreditsToAccount_AddMoneyToAccount_AddedToSuccesfullTransactions()
        {
            // Arrange
            LineSystem lineSystem = CreateLineSystem();
            decimal amount = 50;
            int expected = 1;
            // Act
            lineSystem.AddCreditsToAccount(
                subUser,
                amount);
            int result = lineSystem.SuccessfulTransactions.Count;
            // Assert
            Assert.AreEqual(expected, result);
        }


        [Test]//TODO test when product does not exist
        public void GetProductByID_GetProductById_CorrectProductIsReturned()
        {
            // Arrange
            LineSystem lineSystem = CreateLineSystem();
            ProductCatalog subCatalog = Substitute.For<ProductCatalog>();
            Product subProduct2 = Substitute.For<Product>();
            lineSystem.CurrentProductCatalog = subCatalog;
            subProduct2.Name = "test2";
            subProduct2.ID = 5;
            subProduct2.Active = true;
            subCatalog.AllProducts.Add(subProduct);
            subCatalog.AllProducts.Add(subProduct2);


            int ID = 5;

            // Act
            Product result = lineSystem.GetProductByID(ID);

            // Assert
            Assert.AreEqual(ID, result.ID);
        }

        [Test]//TODO instead check if users are the real ones
        public void GetUsers_GetUsersWithLastNameNielsen_Gets5UsersWithLastNameNielsen()
        {
            // Arrange
            UserDatabase subUserDatabase = Substitute.For<UserDatabase>();
            for (int i = 0; i < 50; i++)
            {
                User newSubUser = Substitute.For<User>();
                newSubUser.FirstName = "test";
                if (i % 10 == 0) newSubUser.LastName = "Nielsen";
                else newSubUser.LastName = "test";
                subUserDatabase.Users.Add(newSubUser);
            }
            LineSystem lineSystem = CreateLineSystem();
            lineSystem.CurrentUserDatabase = subUserDatabase;
            Func<User, bool> predicate = (x => x.LastName == "Nielsen");
            int expected = 5;

            // Act
            int result = lineSystem.GetUsers(predicate).Count;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]//todo test when user not present
        public void GetUserByUsername_FindUserWithUsernameZelda_UserFound()
        {
            // Arrange 
            UserDatabase subUserDatabase = Substitute.For<UserDatabase>();
            subUserDatabase.Users.Add(subUser);
            for (int i = 0; i < 50; i++)
            {
                User newSubUser = Substitute.For<User>();
                newSubUser.FirstName = "test";
                if (i % 10 == 0) newSubUser.LastName = "Nielsen";
                else newSubUser.LastName = "test";
                subUserDatabase.Users.Add(newSubUser);
            }
            LineSystem lineSystem = CreateLineSystem();
            lineSystem.CurrentUserDatabase = subUserDatabase; string username = "zelda";

            // Act
            var result = lineSystem.GetUserByUsername(username);

            // Assert
            Assert.AreEqual(username, result.Username);
        }

        [Test]//test if they are at the right spots
        public void GetTransactions_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            LineSystem lineSystem = CreateLineSystem();
            BuyTransaction subBuyTransaction = Substitute.For<BuyTransaction>();
            subBuyTransaction.User = subUser;
            int expected = 2;

            InsertCashTransaction subInsertCashTransaction = Substitute.For<InsertCashTransaction>();
            subInsertCashTransaction.User = subUser;
            lineSystem.SuccessfulTransactions.Add(subBuyTransaction);
            lineSystem.SuccessfulTransactions.Add(subInsertCashTransaction);
            // Act
            List<Transaction> result = lineSystem.GetTransactions(subUser);

            // Assert
            Assert.AreEqual(expected, result.Count);
        }
    }
}
