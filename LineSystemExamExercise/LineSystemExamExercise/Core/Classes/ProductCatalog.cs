using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Core
{
    /// <summary>
    /// symbolises a product catalog that can import the products from a csv file
    /// </summary>
    public class ProductCatalog
    {
        public ProductCatalog() { }
        public List<Product> AllProducts { get; } = new List<Product>();
        public string Path { get; set; } = "../../../ImportFiles\\products.csv";


        /// <summary>
        /// Imports products from the csv file. if no path is defined, it takes form the Path property. imported products are saved to AllProducts
        /// </summary>
        /// <param name="path">Path for CSV file, default is internal Path</param>
        public void ImportCSVfile(string path = null)
        {
            if (path == null) path = Path;

            AllProducts.Clear();
            string productImport;
            if (!File.Exists(path)) throw new FileNotFoundException($"{path}");//this should not be caught. let program break
            StreamReader reader = new StreamReader(path);
            _ = reader.ReadLine(); //throwaway first line
            while ((productImport = reader.ReadLine()) != null)
            {
                string[] productInfo = productImport.Split(";");
                int id = int.Parse(productInfo[0]);

                string name = productInfo[1];
                name = Regex.Replace(name, "<.*?>|\"", "");

                decimal price = decimal.Parse(productInfo[2]) / 100;
                bool active = int.Parse(productInfo[3]) == 1;
                AllProducts.Add(new Product(id, name, price, active));
            }
        }
    }
}
