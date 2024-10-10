using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.BusinessLayer.Repository;

namespace StudentInfoSystem.BusinessLayer.Services;

public class PaymentServices : IPaymentServices
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

    public decimal GetPaymentAmount(Payment payment)
    {
        return _paymentRepository.GetPaymentAmount(payment);
    }
    public DateTime GetPaymentDate(Payment payment){
        return _paymentRepository.GetPaymentDate(payment);
    }
    public Student GetStudent(Payment payment)
    {
        return _paymentRepository.GetStudent(payment);
    }
}
