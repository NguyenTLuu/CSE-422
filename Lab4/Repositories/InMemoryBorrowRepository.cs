using Lab4.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Repositories
{
    public class InMemoryBorrowRepository : IBorrowRepository
    {
        private readonly List<BorrowRecord> _records = new();

        public void Add(BorrowRecord record)
        {
            _records.Add(record);
        }

        public BorrowRecord? GetById(int id)
        {
            return _records.FirstOrDefault(r => r.Id == id);
        }

        public List<BorrowRecord> GetAll()
        {
            return _records.ToList();
        }
    }
}
