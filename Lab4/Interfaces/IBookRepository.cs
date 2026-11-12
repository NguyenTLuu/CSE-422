using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book? GetById(int id);
        List<Book> GetAll();
    }
}
