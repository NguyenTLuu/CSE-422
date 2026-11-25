using System;
using System.Reflection;

namespace Exercise1
{
    public class Logger
    {
        public void Log<T>(T data)
        {
            if (data == null)
            {
                Console.WriteLine("No data to log.");
                return;
            }

            Type type = data.GetType();

            Console.WriteLine($"Log Type: {type.Name}");

            foreach (PropertyInfo property in type.GetProperties())
            {
                object? value = property.GetValue(data);

                Console.WriteLine(
                    $"{property.Name}: {value}"
                );
            }

            Console.WriteLine("--------------------");
        }
    }
}