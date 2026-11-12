using Lab4.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public class LendingService : ILendingService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IBorrowRepository _borrowRepository;

        public LendingService(
            IBookRepository bookRepository,
            IReaderRepository readerRepository,
            IBorrowRepository borrowRepository)
        {
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _borrowRepository = borrowRepository;
        }

        public bool BorrowBook(int readerId, int bookId)
        {
            Reader? reader = _readerRepository.GetById(readerId);
            Book? book = _bookRepository.GetById(bookId);

            if (reader == null || book == null)
                return false;

            if (book.Quantity <= 0)
                return false;

            int borrowedCount = _borrowRepository.GetAll()
                .Count(r => r.ReaderId == readerId &&
                            r.ReturnDate == null);

            if (borrowedCount >= 3)
                return false;

            List<BorrowRecord> records =
                _borrowRepository.GetAll();

            int newId = records.Count == 0
                ? 1
                : records.Max(r => r.Id) + 1;

            BorrowRecord record = new BorrowRecord
            {
                Id = newId,
                ReaderId = readerId,
                BookId = bookId,
                BorrowDate = DateTime.Now,
                ReturnDate = null
            };

            _borrowRepository.Add(record);

            book.Quantity--;

            return true;
        }

        public bool ReturnBook(int readerId, int bookId)
        {
            Book? book = _bookRepository.GetById(bookId);

            if (book == null)
                return false;

            BorrowRecord? record = _borrowRepository.GetAll()
                .FirstOrDefault(r =>
                    r.ReaderId == readerId &&
                    r.BookId == bookId &&
                    r.ReturnDate == null);

            if (record == null)
                return false;

            record.ReturnDate = DateTime.Now;

            book.Quantity++;

            return true;
        }
    }
}
