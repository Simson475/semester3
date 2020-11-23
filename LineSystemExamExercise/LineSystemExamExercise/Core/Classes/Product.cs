using System;

namespace Core
{
    public class Product
    {
        public Product() { }
        public Product(int id, string name, decimal price, bool active)
        {
            ID = id;
            Name = name;
            Price = price;
            Active = active;
        }
        private string _Name;
        private decimal _Price;

        #region Properties
        public int ID { get; set; }
        public string Name
        {
            get { return _Name; }
            set { _Name = value ?? throw new ArgumentNullException("Name cannot be null"); }
        }

        public decimal Price
        {
            get { return _Price; }
            set
            {
                if (value < 0) throw new ArgumentException("Product Price cannot be less than zero");
                _Price = value;
            }
        }

        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }
        #endregion

        #region Methods
        public override string ToString() => $"{ID}: {Name}, {Price},-";

        #endregion

    }
}
