using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces
{
    public interface IBorrowRepository
    {
        void Add(BorrowRecord record);
        BorrowRecord? GetById(int id);
        List<BorrowRecord> GetAll();
    }
}
