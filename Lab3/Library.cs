using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Library
    {
        public string LibraryName { get; set; }

        public List<Book> Books { get; set; }

        public List<Member> Members { get; set; }

        public Library()
        {
            LibraryName = "Default Library";
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public Library(string libraryName, List<Book> books)
        {
            LibraryName = libraryName;
            Books = books;
            Members = new List<Member>();
        }

        public Library(Library other)
        {
            LibraryName = other.LibraryName;

            Books = new List<Book>(other.Books);

            Members = new List<Member>(other.Members);
        }

        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {LibraryName}");

            Console.WriteLine($"Total Book Titles: {Books.Count}");

            Console.WriteLine($"Total Members: {Members.Count}");

            Console.WriteLine("=== Books ===");

            foreach (Book book in Books)
            {
                book.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine("=== Members ===");

            foreach (Member member in Members)
            {
                member.DisplayInfo();
                Console.WriteLine();
            }
        }

        public event Action<Book, Member>? OnBookBorrowed;
        public void BorrowBook(Book book, Member member)
        {
            if (book.CopiesAvailable > 0)
            {
                book.CopiesAvailable--;

                Console.WriteLine(
                    $"{member.Name} successfully borrowed {book.Title}."
                );

                OnBookBorrowed?.Invoke(book, member);
            }
            else
            {
                Console.WriteLine(
                    "Borrow failed! No copies available."
                );
            }
        }
    }
}
