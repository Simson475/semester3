namespace OOP002Inheritance
{
    class AgeFilter : PersonFilter
    {
        public AgeFilter(int age1, int age2)
        {
            if (age1 < age2)
            {
                MinimumAge = age1;
                MaximumAge = age2;
            }
            else
            {
                MinimumAge = age2;
                MaximumAge = age1;
            }
        }
        private int MinimumAge { get; set; }
        private int MaximumAge { get; set; }

        public override bool FilterPredicate(Person person)
        {

            return person.Age > MinimumAge && person.Age < MaximumAge;
        }
    }
}
