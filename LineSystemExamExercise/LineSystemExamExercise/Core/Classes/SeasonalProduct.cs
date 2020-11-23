using System;

namespace Core
{
    public class SeasonalProduct : Product //TODO constructor and more Test somehow?
    {
        public SeasonalProduct() { }
        public SeasonalProduct(int id, string name, decimal price, bool active) : base(id, name, price, active)
        {
        }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}
