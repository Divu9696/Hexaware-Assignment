using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class InvalidCourseDataException : Exception
{
    public InvalidCourseDataException(string message) : base(message) { }
}
