using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class TeacherNotFoundException : Exception
{
    public TeacherNotFoundException(string message) : base(message) { }
}
