
using Lab4.Interfaces;
using Lab4.Models;
using Lab4.Repositories;
using Lab4.Services;

// ================================
// 1. CREATE REPOSITORIES
// ================================

IBookRepository bookRepository = new InMemoryBookRepository();
IReaderRepository readerRepository = new InMemoryReaderRepository();
IBorrowRepository borrowRepository = new InMemoryBorrowRepository();

// ================================
// 2. CREATE SERVICES
// ================================

IBookService bookService = new BookService(bookRepository);

IReaderService readerService =
    new ReaderService(readerRepository);

ILendingService lendingService = new LendingService(
    bookRepository,
    readerRepository,
    borrowRepository
);

IReportService reportService = new ReportService(
    bookRepository,
    readerRepository,
    borrowRepository
);

// ================================
// 3. ADD SAMPLE DATA
// ================================

bookService.AddBook(new Book
{
    Id = 1,
    Title = "Clean Code",
    Author = "Robert C. Martin",
    Category = "Programming",
    Quantity = 5
});

bookService.AddBook(new Book
{
    Id = 2,
    Title = "Design Patterns",
    Author = "Erich Gamma",
    Category = "Programming",
    Quantity = 3
});

bookService.AddBook(new Book
{
    Id = 3,
    Title = "Harry Potter",
    Author = "J.K. Rowling",
    Category = "Fantasy",
    Quantity = 2
});

bookService.AddBook(new Book
{
    Id = 4,
    Title = "The Hobbit",
    Author = "J.R.R. Tolkien",
    Category = "Fantasy",
    Quantity = 4
});

readerService.AddReader(new Reader
{
    Id = 1,
    Name = "Nguyen Van A"
});

readerService.AddReader(new Reader
{
    Id = 2,
    Name = "Tran Thi B"
});

// ================================
// 4. MAIN MENU
// ================================

while (true)
{
    Console.WriteLine();
    Console.WriteLine("========== LIBRARY MANAGEMENT SYSTEM ==========");
    Console.WriteLine("1. Add New Book");
    Console.WriteLine("2. Search Books by Title");
    Console.WriteLine("3. Search Books by Category");
    Console.WriteLine("4. Add New Reader");
    Console.WriteLine("5. Borrow Book");
    Console.WriteLine("6. Return Book");
    Console.WriteLine("7. Generate Borrow Report");
    Console.WriteLine("8. Display All Books");
    Console.WriteLine("9. Exit");
    Console.WriteLine("===============================================");

    int choice = ReadInt("Enter your choice: ");

    try
    {
        switch (choice)
        {
            case 1:
                AddNewBook();
                break;

            case 2:
                SearchBooksByTitle();
                break;

            case 3:
                SearchBooksByCategory();
                break;

            case 4:
                AddNewReader();
                break;

            case 5:
                BorrowBook();
                break;

            case 6:
                ReturnBook();
                break;

            case 7:
                Console.WriteLine();
                Console.WriteLine(
                    reportService.GenerateBorrowReport());
                break;

            case 8:
                DisplayAllBooks();
                break;

            case 9:
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// ================================
// 5. INPUT HELPER
// ================================

int ReadInt(string message)
{
    while (true)
    {
        Console.Write(message);

        string? input = Console.ReadLine();

        if (input == null)
        {
            Console.WriteLine("Input closed.");
            Environment.Exit(0);
        }

        if (int.TryParse(input, out int number))
        {
            return number;
        }

        Console.WriteLine("Please enter a valid number.");
    }
}

// ================================
// 6. ADD NEW BOOK
// ================================

void AddNewBook()
{
    Console.WriteLine("\n===== ADD NEW BOOK =====");

    int id = ReadInt("Book ID: ");

    Console.Write("Title: ");
    string title = Console.ReadLine() ?? "";

    Console.Write("Author: ");
    string author = Console.ReadLine() ?? "";

    Console.Write("Category: ");
    string category = Console.ReadLine() ?? "";

    int quantity = ReadInt("Quantity: ");

    Book book = new Book
    {
        Id = id,
        Title = title,
        Author = author,
        Category = category,
        Quantity = quantity
    };

    bookService.AddBook(book);

    Console.WriteLine("Book added successfully!");
}

// ================================
// 7. SEARCH BOOKS BY TITLE
// ================================

void SearchBooksByTitle()
{
    Console.WriteLine("\n===== SEARCH BY TITLE =====");

    Console.Write("Enter title: ");
    string title = Console.ReadLine() ?? "";

    List<Book> books = bookService.SearchByTitle(title);

    DisplayBooks(books);
}

// ================================
// 8. SEARCH BOOKS BY CATEGORY
// ================================

void SearchBooksByCategory()
{
    Console.WriteLine("\n===== SEARCH BY CATEGORY =====");

    Console.Write("Enter category: ");
    string category = Console.ReadLine() ?? "";

    List<Book> books = bookService.SearchByCategory(category);

    DisplayBooks(books);
}

// ================================
// 9. ADD NEW READER
// ================================

void AddNewReader()
{
    Console.WriteLine("\n===== ADD NEW READER =====");

    int id = ReadInt("Reader ID: ");

    Console.Write("Reader Name: ");
    string name = Console.ReadLine() ?? "";

    Reader reader = new Reader
    {
        Id = id,
        Name = name
    };

    readerService.AddReader(reader);

    Console.WriteLine("Reader added successfully!");
}

// ================================
// 10. BORROW BOOK
// ================================

void BorrowBook()
{
    Console.WriteLine("\n===== BORROW BOOK =====");

    int readerId = ReadInt("Reader ID: ");
    int bookId = ReadInt("Book ID: ");

    bool success =
        lendingService.BorrowBook(readerId, bookId);

    if (success)
    {
        Console.WriteLine("Book borrowed successfully!");
    }
    else
    {
        Console.WriteLine(
            "Borrow failed. Check reader, book, " +
            "stock, or borrowing limit.");
    }
}

// ================================
// 11. RETURN BOOK
// ================================

void ReturnBook()
{
    Console.WriteLine("\n===== RETURN BOOK =====");

    int readerId = ReadInt("Reader ID: ");
    int bookId = ReadInt("Book ID: ");

    bool success =
        lendingService.ReturnBook(readerId, bookId);

    if (success)
    {
        Console.WriteLine("Book returned successfully!");
    }
    else
    {
        Console.WriteLine(
            "Return failed. No active borrow record found.");
    }
}

// ================================
// 12. DISPLAY ALL BOOKS
// ================================

void DisplayAllBooks()
{
    Console.WriteLine("\n===== ALL BOOKS =====");

    List<Book> books = bookRepository.GetAll();

    DisplayBooks(books);
}

// ================================
// 13. DISPLAY BOOK LIST
// ================================

void DisplayBooks(List<Book> books)
{
    if (books.Count == 0)
    {
        Console.WriteLine("No books found.");
        return;
    }

    Console.WriteLine(
        $"{"ID",-5} {"Title",-25} {"Author",-22} " +
        $"{"Category",-15} {"Quantity",8}");

    Console.WriteLine(new string('-', 80));

    foreach (Book book in books)
    {
        Console.WriteLine(
            $"{book.Id,-5} " +
            $"{book.Title,-25} " +
            $"{book.Author,-22} " +
            $"{book.Category,-15} " +
            $"{book.Quantity,8}");
    }
}
