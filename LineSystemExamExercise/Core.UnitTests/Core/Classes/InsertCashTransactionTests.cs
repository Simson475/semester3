using Core;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class InsertCashTransactionTests
    {
        private User subUser;

        [SetUp]
        public void SetUp()
        {
            subUser = Substitute.For<User>();
            subUser.FirstName = "f";
            subUser.LastName = "l";
            subUser.Email = "t@t.dk";
            subUser.Balance = 1000m;
            Transaction.NextId = 1;
        }

        private InsertCashTransaction CreateInsertCashTransaction()
        {
            return new InsertCashTransaction(subUser, 100m);
        }

        [Test]
        public void ToString_PrintString_StringIsCorrect()
        {
            // Arrange
            InsertCashTransaction insertCashTransaction = CreateInsertCashTransaction();
            string expected = $"1: f l (t@t.dk) Deposited 100 at {DateTime.UtcNow:d/M/yyyy}";

            // Act
            string result = insertCashTransaction.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            InsertCashTransaction insertCashTransaction = CreateInsertCashTransaction();
            decimal expected = 1100;
            // Act
            insertCashTransaction.Execute();

            // Assert
            Assert.AreEqual(expected, subUser.Balance);
        }
    }
}
