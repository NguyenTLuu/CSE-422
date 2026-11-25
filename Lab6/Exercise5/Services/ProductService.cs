using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Services
{
    public class ProductService : IDataService
    {
        public string GetData(int id)
        {
            Console.WriteLine("Fetching product from database...");

            return $"Product {id}";
        }
    }
}
