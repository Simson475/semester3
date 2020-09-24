using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace OOP003interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>()
            {
                new Car(){Make="Skoda", Model = "Fabia", Price = 50000},
                new Car(){Make="vw", Model = "atest", Price = 45000},
                new Car(){Make="Skoda", Model = "Fabia", Price = 5000},
                new Car(){Make="Skoda", Model = "Octavia", Price = 60000}

            };
            cars.Sort(new ModelReversePriceComparer());
            foreach (var item in cars)
            {
                item.Print();
            }

            List<ITaxable> TaxableItems = new List<ITaxable>() {
            new Bus(15, 205781, 150000.5m),
            new Bus(52, 917041, 987461.2m),
            new Bus(28, 182057, 19247.29m),
            new House("Aalborg",true,150, 1294m),
            new House("hasseris",false,84, 10852m)
            };

            foreach (ITaxable item in TaxableItems)
            {
                System.Console.WriteLine(item.TaxValue());
            }
        }
    }
}
