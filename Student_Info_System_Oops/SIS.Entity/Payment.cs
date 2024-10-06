
using System;
namespace SIS.Entity;

// define Payment Class
public class Payment
    {
        public int PaymentID { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }


        // Payement class Constructor
        public Payment(int paymentID, Student student, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            Student = student;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        // Get Student
        public Student GetStudent()
        {
            return Student;
        }


        // Get Payment Amount
        public decimal GetPaymentAmount()
        {
            return Amount;
        }

        // Get Payment Date
        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }
    }