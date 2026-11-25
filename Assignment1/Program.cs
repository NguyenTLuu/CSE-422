
using System;

public enum PaymentType
{
    Card,
    PayPal
}

public interface IPaymentService
{
    void ProcessPayment(PaymentType type, double amount);
}

public interface INotificationService
{
    void SendNotification(double amount);
}

public class PaymentService : IPaymentService
{
    public void ProcessPayment(PaymentType type, double amount)
    {
        switch (type)
        {
            case PaymentType.Card:
                Console.WriteLine("Pay with card: " + amount);
                break;

            case PaymentType.PayPal:
                Console.WriteLine("Pay with paypal: " + amount);
                break;
        }
    }
}

public class NotificationService : INotificationService
{
    private const double VipThreshold = 500;

    public void SendNotification(double amount)
    {
        if (amount > VipThreshold)
        {
            Console.WriteLine("Send VIP email");
        }
        else
        {
            Console.WriteLine("Send normal email");
        }
    }
}

public class OrderService
{
    private readonly IPaymentService paymentService;
    private readonly INotificationService notificationService;

    public OrderService(
        IPaymentService paymentService,
        INotificationService notificationService)
    {
        this.paymentService = paymentService;
        this.notificationService = notificationService;
    }

    public void ProcessOrder(PaymentType type, double amount)
    {
        paymentService.ProcessPayment(type, amount);
        notificationService.SendNotification(amount);
    }
}
