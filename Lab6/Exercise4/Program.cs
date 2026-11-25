using Exercise4;

string[] methods =
{
    "creditcard",
    "paypal",
    "crypto"
};

foreach (string method in methods)
{
    var strategy = PaymentFactory.Create(method);

    var service = new PaymentService(strategy);

    service.ProcessPayment(500);
}