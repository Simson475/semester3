namespace OOP002Inheritance
{
    class NameFilter : PersonFilter
    {
        public NameFilter(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public override bool FilterPredicate(Person person)
        {
            return Name == person.Name;
        }
    }
}
