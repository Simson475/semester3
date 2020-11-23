using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MyFirstUnitTest.UnitTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_numbersAre4And3_Returns7()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            int Result = calculator.Add(4, 3);
            //Assert
            Assert.AreEqual(7, Result);
        }
    }
}