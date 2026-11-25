using Exercise5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Decorators
{
    public class CacheDecorator : IDataService
    {
        private readonly IDataService _service;

        private readonly Dictionary<int, string> _cache
            = new Dictionary<int, string>();

        public CacheDecorator(IDataService service)
        {
            _service = service;
        }

        public string GetData(int id)
        {
            if (_cache.TryGetValue(id, out string? result))
            {
                Console.WriteLine("Fetching from cache...");
                return result;
            }

            result = _service.GetData(id);

            _cache[id] = result;

            return result;
        }
    }
}
