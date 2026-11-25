using Exercise1;

Logger logger = new Logger();

logger.Log(new
{
    Username = "John",
    Action = "Login"
});

logger.Log(new
{
    TransactionId = 101,
    Amount = 500.50
});

logger.Log(new
{
    ErrorMessage = "Connection failed",
    Timestamp = DateTime.Now
});