using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

