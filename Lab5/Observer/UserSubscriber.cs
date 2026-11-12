using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Observer
{
    public class UserSubscriber : ISubscriber
    {
        public string Name { get; private set; }

        public UserSubscriber(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine(
                $"{Name} received notification: {message}"
            );
        }
    }
}
