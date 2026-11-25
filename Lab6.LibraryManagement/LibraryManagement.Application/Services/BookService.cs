using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }

        public Book? GetBookById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException(
                    "Book title cannot be empty."
                );
            }

            _repository.Add(book);
        }
    }
}
