using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class PaymentValidationException : Exception
    {
        public PaymentValidationException(string message) : base(message) { }
    }