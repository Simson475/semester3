using System.Collections.Generic;
using System.IO;

namespace Core
{
    public class ProductCatalog
    {
        public ProductCatalog() { }
        public List<Product> AllProducts { get; set; } = new List<Product>();
        public string Path { get; set; } = "../../../ImportFiles\\products.csv";
        public void ImportCSVfile()
        {
            AllProducts.Clear();
            string productImport;
            if (!File.Exists(Path)) throw new FileNotFoundException($"{Path}");//this should not be caught. let program break
            StreamReader reader = new StreamReader(Path);

            _ = reader.ReadLine(); //throwaway first line
            while ((productImport = reader.ReadLine()) != null)
            {
                string[] productInfo = productImport.Split(";");
                int id = int.Parse(productInfo[0]);

                string name = productInfo[1];
                if (name.StartsWith("\"")) name = name[1..^1];//takes removes first and last element

                while (name.IndexOf("<") != -1)
                {
                    name = name.Remove(name.IndexOf("<"), name.IndexOf(">") - name.IndexOf("<") + 1);
                }

                decimal price = decimal.Parse(productInfo[2]) / 100;
                bool active = int.Parse(productInfo[3]) == 1;
                AllProducts.Add(new Product(id, name, price, active));
            }
        }
    }
}
