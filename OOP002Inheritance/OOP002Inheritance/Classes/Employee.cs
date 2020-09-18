namespace OOP002Inheritance
{
    class Employee : Person
    {
        public Employee(string name, string jobTitle, decimal salary) : base(name)
        {
            JobTitle = jobTitle;
            Salary = salary;
        }
        public Employee(string name, int age, string jobTitle, decimal salary) : base(name, age)
        {
            JobTitle = jobTitle;
            Salary = salary;
        }

        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int Seniority { get; set; } = 0;

        public virtual decimal CalculateYearlySalary()
        {
            return 12 * Salary * (Seniority * 0.1m + 1);
        }
    }


}
