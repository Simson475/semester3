using System;

namespace Core
{
    /// <summary>
    /// symbolises a product in the line system
    /// </summary>
    public class Product
    {
        public Product() { }
        public Product(int id, string name, decimal price, bool active)
        {

            ID = id;
            Name = name;
            Price = price;
            IsActive = active;
            NextID = Math.Max(NextID, id);
        }
        public Product(string name, decimal price, bool active)
        {
            ID = GetNextID();
            Name = name;
            Price = price;
            IsActive = active;
        }

        #region Backing Fields
        private string _Name;
        private decimal _Price;
        #endregion

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

        public virtual bool IsActive { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }
        #endregion

        //ID generation
        public static int NextID { get; set; } = 1;
        public static int GetNextID() => NextID++;

        #region Methods
        public override string ToString() => $"{ID}: {Name}, {Price},-";

        #endregion

    }
}
