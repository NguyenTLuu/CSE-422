using Lab4.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Repositories
{
    public class InMemoryReaderRepository : IReaderRepository
    {
        private readonly List<Reader> _readers = new();

        public void Add(Reader reader)
        {
            _readers.Add(reader);
        }

        public Reader? GetById(int id)
        {
            return _readers.FirstOrDefault(r => r.Id == id);
        }

        public List<Reader> GetAll()
        {
            return _readers.ToList();
        }
    }
}
