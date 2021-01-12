using Core;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;

namespace Core.UnitTests.Core.Classes
{
    [TestFixture]
    public class TxtLoggerTests
    {
        private ILineSystem subLineSystem;
        private readonly string Path = "./test.txt";

        [SetUp]
        public void SetUp()
        {
            subLineSystem = Substitute.For<LineSystem>();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(Path);
        }

        private TxtLogger CreateTxtLogger()
        {
            return new TxtLogger(
                subLineSystem, Path);
        }

        [Test]
        public void LogTransaction_LogATransaction_TransactionIsLoggedToFIle()
        {
            // Arrange
            var txtLogger = CreateTxtLogger();
            object sender = null;
            string expected = "0:  Bought  for 0 at 1/1/0001\r\n";
            BuyTransaction transaction = Substitute.For<BuyTransaction>();
            transaction.Product = Substitute.For<Product>();


            // Act
            txtLogger.LogTransaction(
                sender,
                transaction);

            string result = File.ReadAllText(Path);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
