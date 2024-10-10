using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class InvalidEnrollmentDataException : Exception
{
    public InvalidEnrollmentDataException(string message) : base(message) { }
}
