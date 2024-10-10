using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Exceptions;

namespace StudentInfoSystem.BusinessLayer.Repository;

public class PaymentRepository : IPaymentRepository
{   

    Payment p=new Payment();
    public PaymentRepository()
    {
        
    }
    public PaymentRepository(int paymentID, int studentID, decimal amount, DateTime paymentDate)
        {
            p.PaymentID = paymentID;
            p.Student.StudentID = studentID;
            p.Amount = amount;
            p.PaymentDate = paymentDate;
        }
    public decimal GetPaymentAmount(Payment payment)
        {
            if (payment == null)
                throw new PaymentValidationException("Payment not found.");
            Console.WriteLine($"Payment Amount: {payment.Amount:C}");
            return payment.Amount;
        }

        public DateTime GetPaymentDate(Payment payment)
        {
            if (payment == null)
                throw new PaymentValidationException("Payment not found.");
            Console.WriteLine($"Payment Date: {payment.PaymentDate}");
            return payment.PaymentDate;
        }

        public Student GetStudent(Payment payment)
        {
            if (payment == null)
                throw new PaymentValidationException("Payment not found.");
            Console.WriteLine("Retrieving student associated with the payment.");
            return new Student();
            
        }
}
