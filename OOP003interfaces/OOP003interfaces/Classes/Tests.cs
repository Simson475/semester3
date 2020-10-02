using System;
using System.Collections.Generic;

namespace OOP003interfaces
{
    public static class Tests
    {
        public static void CardAndDie()
        {
            Die d1 = new Die(),
            d2 = new Die(10),
            d3 = new Die(18);

            Card c1 = new Card(Card.CardSuite.spades, Card.CardValue.queen),
                 c2 = new Card(Card.CardSuite.clubs, Card.CardValue.four),
                 c3 = new Card(Card.CardSuite.diamonds, Card.CardValue.ace);

            GameObject[] gameObjects = { d1, d2, d3, c1, c2, c3 };

            foreach (GameObject gao in gameObjects)
            {
                Console.WriteLine("{0}: {1} {2}",
                                  gao, gao.GameValue, gao.Medium);
            }
        }
        public static void Cars()
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
        }
        public static void Taxable()
        {

            List<ITaxable> TaxableItems = new List<ITaxable>() {
            new Bus(15, 205781, 150000.5m),
            new Bus(52, 917041, 987461.2m),
            new Bus(28, 182057, 19247.29m),
            new House("Aalborg",true,150, 1294m),
            new House("hasseris",false,84, 10852m)
            };

            foreach (ITaxable item in TaxableItems)
            {
                Console.WriteLine(item.TaxValue());
            }
        }
    }
}
