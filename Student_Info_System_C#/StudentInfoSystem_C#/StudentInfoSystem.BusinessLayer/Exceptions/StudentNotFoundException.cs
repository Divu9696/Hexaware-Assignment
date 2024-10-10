using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string message) : base(message) { }
}

