using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Services
{
    public class UserService : IDataService
    {
        public string GetData(int id)
        {
            Console.WriteLine("Fetching user from database...");

            return $"User {id}";
        }
    }
}
