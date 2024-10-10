using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class InvalidStudentDataException : Exception
    {
        public InvalidStudentDataException(string message) : base(message) { }
    }
