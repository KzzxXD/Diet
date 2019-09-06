using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.BL.Models
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }
        public bool IsAllergen { get; set; }

        public Product(string name, DateTime dateAdd, bool isAllergen)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ім'я не може бути пустим", nameof(name));
            }

            Name = name;
            DateAdd = dateAdd;
            IsAllergen = isAllergen;
        }
        public Product(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Iм'я: {Name}, \t Дата додавання {DateAdd}";
        }
    }
}
