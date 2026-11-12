using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> SearchByTitle(string title);
        List<Book> SearchByCategory(string category);
    }
}
