using System;
using System.Collections.Generic;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository;

public interface IPaymentRepository
{
    public decimal GetPaymentAmount(Payment payment);
    
    public DateTime GetPaymentDate(Payment payment);
    
    public Student GetStudent(Payment payment);
    
}
