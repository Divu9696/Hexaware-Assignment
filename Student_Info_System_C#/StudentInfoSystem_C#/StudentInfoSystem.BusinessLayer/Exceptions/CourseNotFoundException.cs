using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class CourseNotFoundException : Exception
{
    public CourseNotFoundException(string message) : base(message) { }
}

