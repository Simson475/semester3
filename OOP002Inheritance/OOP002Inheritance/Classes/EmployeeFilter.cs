namespace OOP002Inheritance
{
    class EmployeeFilter : PersonFilter
    {
        public override bool FilterPredicate(Person person)
        {
            return person is Employee;
        }
    }
}

