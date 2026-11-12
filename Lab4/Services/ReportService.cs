using Lab4.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public class ReportService : IReportService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IBorrowRepository _borrowRepository;

        public ReportService(
            IBookRepository bookRepository,
            IReaderRepository readerRepository,
            IBorrowRepository borrowRepository)
        {
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _borrowRepository = borrowRepository;
        }

        public string GenerateBorrowReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine("===== LIBRARY BORROW REPORT =====");
            report.AppendLine();

            List<Reader> readers = _readerRepository.GetAll();
            List<BorrowRecord> records =
                _borrowRepository.GetAll();

            foreach (Reader reader in readers)
            {
                report.AppendLine($"Reader ID: {reader.Id}");
                report.AppendLine($"Reader Name: {reader.Name}");
                report.AppendLine("Borrowed Books:");

                List<BorrowRecord> borrowedBooks = records
                    .Where(r => r.ReaderId == reader.Id &&
                                r.ReturnDate == null)
                    .ToList();

                if (borrowedBooks.Count == 0)
                {
                    report.AppendLine("- No borrowed books");
                }
                else
                {
                    foreach (BorrowRecord record in borrowedBooks)
                    {
                        Book? book =
                            _bookRepository.GetById(record.BookId);

                        if (book != null)
                        {
                            report.AppendLine($"- {book.Title}");
                        }
                    }
                }

                report.AppendLine(
                    $"Total Borrowed: {borrowedBooks.Count}");

                report.AppendLine("--------------------------------");
            }

            return report.ToString();
        }
    }
}
