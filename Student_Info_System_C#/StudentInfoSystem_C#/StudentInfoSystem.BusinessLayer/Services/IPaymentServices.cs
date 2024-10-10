using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
namespace StudentInfoSystem.BusinessLayer.Services;

public interface IPaymentServices
{
    public decimal GetPaymentAmount(Payment payment);
    public DateTime GetPaymentDate(Payment payment);
    public Student GetStudent(Payment payment);
}
