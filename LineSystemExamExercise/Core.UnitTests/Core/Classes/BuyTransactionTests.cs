using Core;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class BuyTransactionTests
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
            subUser.FirstName = "f";
            subUser.LastName = "l";
            subUser.Email = "t@t.dk";
            subUser.Balance = 1000m;
            Transaction.NextId = 1;

        }

        private BuyTransaction CreateBuyTransaction()
        {
            return new BuyTransaction(subUser, subProduct);
        }

        [Test]
        public void ToString_PrintingObject_ObjectIsPrintedCorrect()
        {
            // Arrange
            BuyTransaction buyTransaction = CreateBuyTransaction();
            string expected = $"1: f l (t@t.dk) Bought prod for 100 at {DateTime.UtcNow:d/M/yyyy}";
            // Act
            string result = buyTransaction.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Execute_NotEnoughMoney_ErrorIsThrown()
        {
            // Arrange
            subUser.Balance = 0;
            BuyTransaction buyTransaction = CreateBuyTransaction();
            string expected = "Insufficient Credits for purchase!";
            // Act
            try
            {
                buyTransaction.Execute();

            }
            catch (InsufficientCreditsException e)
            {
                // Assert
                Assert.AreEqual(expected, e.Message);
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void Execute_InactiveProduct_ErrorIsThrown()
        {
            // Arrange
            subProduct.Active = false;
            BuyTransaction buyTransaction = CreateBuyTransaction();
            string expected = $"{subProduct.Name} is unavailable, you have not been billed.";
            // Act
            try
            {
                buyTransaction.Execute();
            }
            catch (InactiveProductException e)
            {
                // Assert
                Assert.AreEqual(expected, e.Message);
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void Execute_WithEnoughMoney_ExecuteAndRemoveMoneyFromBalance()
        {
            // Arrange

            BuyTransaction buyTransaction = CreateBuyTransaction();
            decimal expectedBalance = 900m;
            // Act
            buyTransaction.Execute();

            // Assert
            Assert.AreEqual(expectedBalance, subUser.Balance);
        }
    }
}
