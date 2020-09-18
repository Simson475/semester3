namespace OOP002Inheritance
{
    class NotFilter : PersonFilter
    {
        public PersonFilter FilterType { get; set; }
        public NotFilter(PersonFilter filterType) : base()
        {
            FilterType = filterType;
        }
        public override bool FilterPredicate(Person person)
        {
            return !FilterType.FilterPredicate(person);
        }

    }
}

