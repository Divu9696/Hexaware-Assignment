using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class DuplicateEnrollmentException : Exception
{
    public DuplicateEnrollmentException(string message) : base(message) { }
}

