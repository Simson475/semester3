namespace OOP009Collections
{
    public class Person
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name}: \n Weight: {Weight}\n Age: {Age}\n";
        }
    }
}

