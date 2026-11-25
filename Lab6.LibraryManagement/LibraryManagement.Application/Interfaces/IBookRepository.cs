using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        Book? GetById(int id);

        void Add(Book book);
    }
}