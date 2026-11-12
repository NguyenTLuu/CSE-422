using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces
{
    public interface ILendingService
    {
        bool BorrowBook(int readerId, int bookId);
        bool ReturnBook(int readerId, int bookId);
    }
}
