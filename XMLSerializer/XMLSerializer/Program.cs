using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Age = new AgeClass() { AgeInYears = 27 },
                Male = true,
                Name = "Simon Nielsen"
            };
            person.Save("hey.xml");
            person = Person.LoadFromFile("hey.xml");
            Console.WriteLine(person);
        }
    }

    public class AgeClass
    {
        public int AgeInYears { get; set; }
    }

    public class Person
    {
        public AgeClass Age { get; set; }
        public bool Male { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}, age {Age.AgeInYears}, {(Male ? "Male" : "Female")}";
        }
        public void Save(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            XmlSerializer XML = new XmlSerializer(typeof(Person));
            XML.Serialize(stream, this);
        }

        public static Person LoadFromFile(string fileName)
        {
            {
                FileStream test = new FileStream("asdjkl.xml", FileMode.Open);
                FileStream stream = new FileStream(fileName, FileMode.Open);
                XmlSerializer XML = new XmlSerializer(typeof(Person));
                return (Person)XML.Deserialize(stream);

            }
        }
    }
}