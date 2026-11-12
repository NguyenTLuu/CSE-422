using Lab4.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (book.Id <= 0)
                throw new ArgumentException("Book ID must be positive.");

            if (string.IsNullOrWhiteSpace(book.Title) ||
                string.IsNullOrWhiteSpace(book.Author) ||
                string.IsNullOrWhiteSpace(book.Category))
            {
                throw new ArgumentException(
                    "Title, Author and Category are required.");
            }

            if (book.Quantity < 0)
                throw new ArgumentException(
                    "Quantity cannot be negative.");

            if (_bookRepository.GetById(book.Id) != null)
                throw new InvalidOperationException(
                    "Book ID already exists.");

            _bookRepository.Add(book);
        }

        public List<Book> SearchByTitle(string title)
        {
            return _bookRepository.GetAll()
                .Where(b => b.Title.Contains(
                    title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Book> SearchByCategory(string category)
        {
            return _bookRepository.GetAll()
                .Where(b => b.Category.Contains(
                    category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
