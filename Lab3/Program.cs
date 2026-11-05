using Lab3;

// ======== Exercise 1-4 ========

// Create a Book object
//Book book = new Book();

//// Assign values
//book.ISBN = "9780132350884";
//book.Title = "Clean Code";
//book.Author = "Robert C. Martin";
//book.Year = 2008;
//book.CopiesAvailable = 5;

//// Display information
//book.DisplayInfo();

//// Normal Member
//Member member = new Member
//{
//    MemberID = "M001",
//    Name = "Nguyen Van A",
//    Email = "a@gmail.com"
//};

//// Premium Member
//PremiumMember premium = new PremiumMember
//{
//    MemberID = "001",
//    Name = "Tran Thi B",
//    Email = "b@gmail.com",
//    MembershipExpiry = new DateTime(2026, 10, 29),
//    MaxBooksAllowed = 10
//};
//Console.WriteLine();


//// Display normal member
//Console.WriteLine("=== NORMAL MEMBER ===");
//member.DisplayInfo();

//Console.WriteLine();

//// Display premium member
//Console.WriteLine("=== PREMIUM MEMBER ===");
//premium.DisplayInfo();

//// Create a borrow transaction
//BorrowTransaction borrow = new BorrowTransaction
//{
//    TransactionID = "T001",
//    TransactionDate = DateTime.Now,
//    Member = member,
//    BookBorrowed = book
//};


//// Create a return transaction
//ReturnTransaction returnTransaction = new ReturnTransaction
//{
//    TransactionID = "T002",
//    TransactionDate = DateTime.Now,
//    Member = member,
//    BookReturned = book
//};

//List<Transaction> transactions = new List<Transaction>();
//transactions.Add(returnTransaction);
//transactions.Add(borrow);

//foreach (var transaction in transactions)
//{
//    Console.WriteLine();
//    Console.WriteLine($"=== TRANSACTION {transaction.TransactionID} ===");
//    transaction.Execute();
//}


// ======== Exercise 5 ======== //

//// Test IPrintable
//Console.WriteLine("=== BOOK INFORMATION ===");
//book.PrintDetails();

//Console.WriteLine();
//Console.WriteLine("=== NORMAL MEMBER ===");
//member.PrintDetails();

//Console.WriteLine();
//Console.WriteLine("=== PREMIUM MEMBER ===");
//premium.PrintDetails();

//// Test IMemberActions
//Console.WriteLine();
//Console.WriteLine("=== BORROW BOOK ===");

//member.BorrowBook(book);
//premium.BorrowBook(book);

//// Return books
//Console.WriteLine();
//Console.WriteLine("=== RETURN BOOK ===");

//member.ReturnBook(book);
//premium.ReturnBook(book);

//// Final book information
//Console.WriteLine();
//Console.WriteLine("=== FINAL BOOK STATUS ===");
//book.PrintDetails();

// ======== Exercise 6 ======== // 

//// 1. Default Constructor
//Library library1 = new Library();

//Console.WriteLine("=== DEFAULT CONSTRUCTOR ===");
//library1.DisplayLibraryInfo();

//// 2. Create sample books
//List<Book> books = new List<Book>
//{
//    new Book
//    {
//        ISBN = "B001",
//        Title = "Clean Code",
//        Author = "Robert C. Martin",
//        Year = 2008,
//        CopiesAvailable = 5
//    },

//    new Book
//    {
//        ISBN = "B002",
//        Title = "Design Patterns",
//        Author = "Erich Gamma",
//        Year = 1994,
//        CopiesAvailable = 3
//    }
//};

//// 3. Parameterized Constructor
//Library library2 = new Library("University Library", books);

//library2.Members.Add(new Member
//{
//    MemberID = "M001",
//    Name = "Nguyen Van A",
//    Email = "a@gmail.com"
//});

//Console.WriteLine();
//Console.WriteLine("=== PARAMETERIZED CONSTRUCTOR ===");
//library2.DisplayLibraryInfo();

//// 4. Copy Constructor
//Library library3 = new Library(library2);

//Console.WriteLine();
//Console.WriteLine("=== COPY CONSTRUCTOR ===");
//library3.DisplayLibraryInfo();

// ======= Exercise 7 ======== //

//// Create notification service
//NotificationService service = new NotificationService();

//// Test Method Overloading
//Console.WriteLine("=== METHOD OVERLOADING ===");

//// 1. General notification
//service.SendNotification("Welcome to the library!");

//Console.WriteLine();

//// 2. Notification to one recipient
//service.SendNotification(
//    "Your borrowed book is due tomorrow.",
//    "Nguyen Van A"
//);

//Console.WriteLine();

//// 3. Notification to multiple recipients
//List<string> recipients = new List<string>
//{
//    "Nguyen Van A",
//    "Tran Thi B",
//    "Le Van C"
//};

//service.SendNotification(
//    "The library will be closed on Sunday.",
//    recipients
//);

//// Test Method Overriding
//Console.WriteLine();
//Console.WriteLine("=== METHOD OVERRIDING ===");

//AdvancedNotificationService advanced =
//    new AdvancedNotificationService();

//advanced.SendNotification("Your book is overdue!");

//// Test Runtime Polymorphism
//Console.WriteLine();
//Console.WriteLine("=== POLYMORPHISM ===");

//NotificationService polymorphic =
//    new AdvancedNotificationService();

//polymorphic.SendNotification("Please return your book.");

// ======= Exercise 8 ======== //

// Create members
//Member member1 = new Member
//{
//    MemberID = "M001",
//    Name = "Nguyen Van A",
//    Email = "a@gmail.com"
//};

//Member member2 = new Member
//{
//    MemberID = "M002",
//    Name = "Tran Thi B",
//    Email = "b@gmail.com"
//};

//// Create a library card
//LibraryCard card = new LibraryCard("C001", member1);

//// Display original card
//Console.WriteLine("=== ORIGINAL CARD ===");
//card.DisplayCardInfo();

//// Change card owner
//Console.WriteLine();
//Console.WriteLine("=== CHANGE OWNER ===");

//card.Owner = member2;
//card.DisplayCardInfo();

//// Renew card
//Console.WriteLine();
//Console.WriteLine("=== RENEW CARD ===");

//card.RenewCard();
//card.DisplayCardInfo();

//// Read properties
//Console.WriteLine();
//Console.WriteLine("=== READ PROPERTIES ===");

//Console.WriteLine($"Card Number: {card.CardNumber}");
//Console.WriteLine($"Owner Name: {card.Owner.Name}");
//Console.WriteLine($"Issue Date: {card.IssueDate}");

// ======= Exercise 9 ======== //

//// 1. CLASS COMPARISON
//Console.WriteLine("=== CLASS COMPARISON ===");

//BookClass book1 = new BookClass
//{
//    ISBN = "B001",
//    Title = "Clean Code",
//    Author = "Robert C. Martin"
//};

//BookClass book2 = new BookClass
//{
//    ISBN = "B001",
//    Title = "Clean Code",
//    Author = "Robert C. Martin"
//};

//Console.WriteLine($"book1 == book2: {book1 == book2}");

//BookClass book3 = book1;

//Console.WriteLine($"book1 == book3: {book1 == book3}");

//// 2. RECORD COMPARISON
//Console.WriteLine();
//Console.WriteLine("=== RECORD COMPARISON ===");

//BookRecord record1 = new BookRecord
//{
//    ISBN = "B001",
//    Title = "Clean Code",
//    Author = "Robert C. Martin"
//};

//BookRecord record2 = new BookRecord
//{
//    ISBN = "B001",
//    Title = "Clean Code",
//    Author = "Robert C. Martin"
//};

//Console.WriteLine($"record1 == record2: {record1 == record2}");

//// 3. RECORD COPYING WITH 'with'
//Console.WriteLine();
//Console.WriteLine("=== RECORD COPYING ===");

//BookRecord record3 = record1 with
//{
//    Title = "Clean Architecture"
//};

//Console.WriteLine($"Original title: {record1.Title}");
//Console.WriteLine($"Copied title: {record3.Title}");

//Console.WriteLine($"record1 == record3: {record1 == record3}");

//// 4. COPY WITHOUT CHANGES
//Console.WriteLine();
//Console.WriteLine("=== RECORD COPY WITHOUT CHANGES ===");

//BookRecord record4 = record1 with { };

//Console.WriteLine($"record1 == record4: {record1 == record4}");

//Console.WriteLine(
//    $"ReferenceEquals(record1, record4): {ReferenceEquals(record1, record4)}"
//);

//// 5. MANUAL CLASS COPYING
//Console.WriteLine();
//Console.WriteLine("=== CLASS MANUAL COPYING ===");

//BookClass book4 = new BookClass
//{
//    ISBN = book1.ISBN,
//    Title = "Clean Architecture",
//    Author = book1.Author
//};

//Console.WriteLine($"Original class title: {book1.Title}");
//Console.WriteLine($"Copied class title: {book4.Title}");

// === Exercise 10 ======== //
// Create a book
Book book = new Book
{
    ISBN = "B001",
    Title = "Clean Code",
    Author = "Robert C. Martin",
    Year = 2008,
    CopiesAvailable = 2
};

// Create a member
Member member = new Member
{
    MemberID = "M001",
    Name = "Nguyen Van A",
    Email = "a@gmail.com"
};

// Create a library
Library library = new Library(
    "University Library",
    new List<Book> { book }
);

library.Members.Add(member);

// Create notification service
NotificationService notification = new NotificationService();

// Register two subscribers
library.OnBookBorrowed += notification.NotifyBorrowed;
library.OnBookBorrowed += LogBorrow;


// TEST 1: Two subscribers
Console.WriteLine("=== FIRST BORROW ===");

library.BorrowBook(book, member);


// Unsubscribe NotificationService
library.OnBookBorrowed -= notification.NotifyBorrowed;


// TEST 2: Only LogBorrow remains
Console.WriteLine();
Console.WriteLine("=== SECOND BORROW ===");

library.BorrowBook(book, member);


// TEST 3: No copies available
Console.WriteLine();
Console.WriteLine("=== THIRD BORROW ===");

library.BorrowBook(book, member);


// Final book status
Console.WriteLine();
Console.WriteLine("=== FINAL BOOK STATUS ===");

book.DisplayInfo();


// Another event handler
static void LogBorrow(Book book, Member member)
{
    Console.WriteLine(
        $"LOG: {member.Name} borrowed {book.Title}."
    );
}