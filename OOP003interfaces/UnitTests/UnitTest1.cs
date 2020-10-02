using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP003interfaces;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestModelReverseePriceComparer()
        {

            List<Car> ExpectedOutput = new List<Car> {
                new Car(){Make="vw", Model = "atest", Price = 45000},
                new Car(){Make="Skoda", Model = "Fabia", Price = 50000},
                new Car(){Make="Skoda", Model = "Fabia", Price = 5000},
                new Car(){Make="Skoda", Model = "Octavia", Price = 60000}

};
            List<Car> Input = new List<Car>()
            {
                new Car(){Make="Skoda", Model = "Fabia", Price = 50000},
                new Car(){Make="vw", Model = "atest", Price = 45000},
                new Car(){Make="Skoda", Model = "Fabia", Price = 5000},
                new Car(){Make="Skoda", Model = "Octavia", Price = 60000}
            };

            Input.Sort(new ModelReversePriceComparer());

            Assert.AreEqual(Input.Count, ExpectedOutput.Count);
            for (int i = 0; i < Input.Count; i++)
            {
                Assert.AreEqual(Input[i].Make, ExpectedOutput[i].Make);
                Assert.AreEqual(Input[i].Model, ExpectedOutput[i].Model);
                Assert.AreEqual(Input[i].Price, ExpectedOutput[i].Price);

            }
        }
    }
}
