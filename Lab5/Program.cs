
using Lab5;
using Lab5.Factory;
using Lab5.Observer;
using Lab5.Singleton;
using Lab5.Strategy;

// ======================================
// 1. Singleton Pattern
// ======================================

Console.WriteLine("=== Singleton Pattern ===");

var db1 = DatabaseConnection.GetInstance();
var db2 = DatabaseConnection.GetInstance();

db1.ExecuteQuery("SELECT * FROM Documents");

Console.WriteLine(
    $"Same instance: {ReferenceEquals(db1, db2)}"
);


// ======================================
// 2. Factory Pattern
// ======================================

Console.WriteLine("\n=== Factory Pattern ===");

IDocument book = DocumentFactory.CreateDocument(
    "book", "Design Patterns"
);

IDocument magazine = DocumentFactory.CreateDocument(
    "magazine", "Technology Today"
);

IDocument newspaper = DocumentFactory.CreateDocument(
    "newspaper", "Daily News"
);

book.DisplayInfo();
magazine.DisplayInfo();
newspaper.DisplayInfo();


// ======================================
// 3. Observer Pattern
// ======================================

Console.WriteLine("\n=== Observer Pattern ===");

var notifier = new LibraryNotifier();

var user1 = new UserSubscriber("Alice");
var user2 = new UserSubscriber("Bob");

notifier.Subscribe(user1);
notifier.Subscribe(user2);

// New document notification
notifier.NotifySubscribers(
    "New book added: Design Patterns"
);

// Borrow notification
notifier.NotifySubscribers(
    "Book borrowed: Design Patterns"
);

// Return notification
notifier.NotifySubscribers(
    "Book returned: Design Patterns"
);


// ======================================
// 4. Strategy Pattern
// ======================================

Console.WriteLine("\n=== Strategy Pattern ===");

var bookLoan = new Loan(new BookFeeStrategy());

var magazineLoan = new Loan(
    new MagazineFeeStrategy()
);

var newspaperLoan = new Loan(
    new NewspaperFeeStrategy()
);

Console.WriteLine(
    $"Book fee for 5 days: {bookLoan.GetFee(5)} VND"
);

Console.WriteLine(
    $"Magazine fee for 5 days: {magazineLoan.GetFee(5)} VND"
);

Console.WriteLine(
    $"Newspaper fee for 5 days: {newspaperLoan.GetFee(5)} VND"
);
