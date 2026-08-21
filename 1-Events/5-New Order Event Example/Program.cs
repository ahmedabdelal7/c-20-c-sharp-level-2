using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class OrderEventArgs : EventArgs
{
    public int OrderID { get; }
    public double TotalPrice {  get; }
    public string OrderDescription {  get; }    
    public string PersonEmail {  get; }
    public string PersonPhoneNumber {  get; }


    public OrderEventArgs(int orderID, double totalPrice, string orderDescription, string personEmail, string personPhoneNumber)
    {
        OrderID = orderID;
        TotalPrice = totalPrice;
        OrderDescription = orderDescription;
        PersonEmail = personEmail;
        PersonPhoneNumber = personPhoneNumber;
    }
}

public class Order
{
    public event EventHandler<OrderEventArgs> OnOrderCreated;

    public void CreateOrder(int orderID, double orderTotalPrice, string orderDescription, string personEmail, string personPhoneNumber)
    {
        Console.WriteLine("Order is created ,now we will notify all subscribers.\n");

        if (OnOrderCreated != null)
        {
            //raise the event and notify all subscribers.
            OnOrderCreated(this, new OrderEventArgs(orderID, orderTotalPrice, orderDescription,personEmail,personPhoneNumber));
        }

    }
}

public class EmailService
{
    public void Subscribe(Order order)
    {
        order.OnOrderCreated += HandelOnOrderCreated;
    }

    public void UnSubscribe(Order order)
    {
        order.OnOrderCreated -= HandelOnOrderCreated;
    }

    public void HandelOnOrderCreated(object sender, OrderEventArgs e)
    {
        Console.WriteLine("------------Email Service------------");
        Console.WriteLine($"Your order placed successfully with id: {e.OrderID}");
        Console.WriteLine($"Order Price       : {e.TotalPrice}.");
        Console.WriteLine($"Order Description : {e.TotalPrice}.");
        Console.WriteLine($"Person Email      : {e.PersonEmail}");
        Console.WriteLine();
        //Do any thing here and send email....

    }
}

public class SMSService
{
    public void Subscribe(Order order)
    {
        order.OnOrderCreated += HandelOnOrderCreated;
    }

    public void UnSubscribe(Order order)
    {
        order.OnOrderCreated -= HandelOnOrderCreated;
    }

    public void HandelOnOrderCreated(object sender, OrderEventArgs e)
    {
        Console.WriteLine("------------SMS Service------------");
        Console.WriteLine($"Your order placed successfully with id: {e.OrderID}");
        Console.WriteLine($"Order Price       : {e.TotalPrice}.");
        Console.WriteLine($"Order Description : {e.TotalPrice}.");
        Console.WriteLine($"Person Phone      : {e.PersonPhoneNumber}");
        Console.WriteLine();
        //Do any thing here and send email....

    }
}

public class ShippingService
{
    public void Subscribe(Order order)
    {
        order.OnOrderCreated += HandelOnOrderCreated;
    }

    public void UnSubscribe(Order order)
    {
        order.OnOrderCreated -= HandelOnOrderCreated;
    }

    public void HandelOnOrderCreated(object sender, OrderEventArgs e)
    {
        Console.WriteLine("------------Shipping Service------------");
        Console.WriteLine($"Order id: {e.OrderID}");
        Console.WriteLine($"Order Price       : {e.TotalPrice}.");
        Console.WriteLine($"Order Description : {e.TotalPrice}.");
        Console.WriteLine($"Person Phone      : {e.PersonPhoneNumber}");
        Console.WriteLine($"Person Email      : {e.PersonEmail}");
        Console.WriteLine();

        //Do any thing here and send email....

    }
}


public class Program
{
    static void Main(string[] args)
    {
        
        Order order = new Order();

        EmailService emailService = new EmailService();
        emailService.Subscribe(order);

        SMSService smsService = new SMSService();
        smsService.Subscribe(order);

        ShippingService shippingService = new ShippingService();
        shippingService.Subscribe(order);


        order.CreateOrder(1, 120, "Sun Glasses.", "ahmed@gmail.com", "010021516");

        shippingService.UnSubscribe(order);

        order.CreateOrder(2, 50, "T-Shirt", "Mona@gmail.com", "012584876");

        emailService.UnSubscribe(order);

        order.CreateOrder(3, 850, "Iphone 13pro.", "Salah@gmail.com", "02258494");



        Console.ReadKey();

    }
}
