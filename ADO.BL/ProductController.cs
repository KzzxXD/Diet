using ADO.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ADO.BL
{
    public class ProductController
    {

        public List<Product> Products { get; }
        public Product CurrentProduct { get; }
        public bool IsNew { get; } = false;
        public void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream("products.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(file, Products);
            }
        }
   
        public ProductController(string name)
        {
            Products = GetProducts();
            CurrentProduct = Products.SingleOrDefault(x => x.Name == name);
            if(CurrentProduct == null)
            {
                CurrentProduct = new Product(name);
                Products.Add(CurrentProduct);
                IsNew = true;
                Save();
            }
            else
            {
                Console.WriteLine("Такий продукт вже існує, і додавати його не потрібно");
            }
        }

        public List<Product> GetProducts()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream("products.dat", FileMode.OpenOrCreate))
            {
                if(file.Length > 0 && binaryFormatter.Deserialize(file) is List<Product> products)
                {
                    return products;
                }
                else
                {
                    return new List<Product>();
                }
            }
        }

        public void SetData(string name, DateTime dateAdd, bool isAllergen)
        {
            CurrentProduct.Name = name;
            CurrentProduct.DateAdd = dateAdd;
            CurrentProduct.IsAllergen = isAllergen;
            Save();
        } 

        public ProductController() {
            Products = GetProducts();
        }
        public List<Product> GetAllrgicProducts()
        {
            var isAllergic = Products.Where(x => x.IsAllergen == true).ToList();
            return isAllergic;
        }
    }
}
