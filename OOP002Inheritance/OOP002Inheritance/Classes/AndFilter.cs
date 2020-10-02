namespace OOP002Inheritance
{
    class AndFilter : PersonFilter
    {
        public PersonFilter Filter1 { get; set; }
        public PersonFilter Filter2 { get; set; }

        public AndFilter(PersonFilter filter1, PersonFilter filter2) : base()
        {
            Filter1 = filter1;
            Filter2 = filter2;
        }

        public override bool FilterPredicate(Person person)
        {
            return Filter1.FilterPredicate(person) && Filter2.FilterPredicate(person);
        }
    }
}

