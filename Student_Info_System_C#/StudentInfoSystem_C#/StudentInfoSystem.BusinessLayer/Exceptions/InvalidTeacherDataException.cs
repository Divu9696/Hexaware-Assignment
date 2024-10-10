using System;

namespace StudentInfoSystem.BusinessLayer.Exceptions;

public class InvalidTeacherDataException : Exception
    {
        public InvalidTeacherDataException(string message) : base(message) { }
    }
