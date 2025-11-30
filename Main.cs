using System;
using SolidPaymentSystem;

namespace PaymentApp
{
    class Program
    {
        static void Main()
        {
            // Creating the processor
            PaymentProcessor processor = new PaymentProcessor();

            // LSP: Both classes are used through the PaymentMethod abstraction
            PaymentMethod creditCard = new CreditCardPayment();
            PaymentMethod paypal = new PayPalPayment();

            // Execute credit card payment
            processor.Process(creditCard, 150.00);

            // Execute PayPal payment
            processor.Process(paypal, 89.99);
        }
    }
}
