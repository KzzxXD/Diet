using ADO.BL;
using ADO.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привіт, виберіть дію");
            while (true)
            {
                Console.WriteLine("1) Додати продук");
                Console.WriteLine("2) Всі продукти");
                Console.WriteLine("3) Показати продукти, які є алергенами");
                ProductController productController = new ProductController();
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    Console.WriteLine("Введіть ім'я");
                    string name = Console.ReadLine();
                    productController = new ProductController(name);
                    if (productController.IsNew)
                    {
                        string isAl = Console.ReadLine();
                        bool isAllergen = false;
                        if (isAl.Equals("N"))
                        {
                            isAllergen = false;
                        }
                        else if (isAl.Equals("Y"))
                        {
                            isAllergen = true;

                        }
                        productController.SetData(name, DateTime.Now, isAllergen);

                    }
                }
                else if (choose.Equals("2"))
                {
                    ProductController productController1 = new ProductController();
                    Console.WriteLine("Список всіх продуктів");                  
                    foreach (var item in productController1.Products)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (choose.Equals("3"))
                {
                    Console.WriteLine("Продукти які є алергенами:");
                    List<Product> products = productController.GetAllrgicProducts();
                    foreach(var item in products)
                    {
                        Console.WriteLine($"Iм'я:{item.Name} \t Дата додавання:{item.DateAdd}");
                    }

                   
                }
            }

  
        }
    }
}
