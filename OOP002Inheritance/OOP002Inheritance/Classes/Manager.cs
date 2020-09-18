namespace OOP002Inheritance
{
    class Manager : Employee
    {
        public Manager(string name, string jobTitle, decimal salary, decimal bonus) : base(name, jobTitle, salary)
        {
            Bonus = bonus;
        }
        public Manager(string name, int age, string jobTitle, decimal salary, decimal bonus) : base(name, age, jobTitle, salary)
        {
            Bonus = bonus;
        }

        public decimal Bonus { get; set; }

        public override decimal CalculateYearlySalary()
        {
            return 12 * Salary * (Seniority * 0.1m + 1) + Bonus;
        }
    }


}
