using System;

namespace Core
{
    /// <summary>
    /// Symbolises a product with an active period.
    /// </summary>
    public class SeasonalProduct : Product
    {
        public SeasonalProduct() { }
        public SeasonalProduct(int id, string name, decimal price, bool isActive) : base(id, name, price, isActive)
        {
        }

        public SeasonalProduct(string name, decimal price, bool isActive) : base(name, price, isActive)
        {
        }

        bool _IsActive = true;
        public override bool IsActive
        {
            get
            {
                if (DateTime.Now > SeasonStartDate && DateTime.Now < SeasonEndDate)
                {
                    return _IsActive;
                }
                else return false;
            }
            set
            {
                _IsActive = value;
            }
        }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}
