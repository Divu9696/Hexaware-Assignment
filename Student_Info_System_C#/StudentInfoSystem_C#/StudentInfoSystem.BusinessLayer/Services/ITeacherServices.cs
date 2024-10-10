using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
namespace StudentInfoSystem.BusinessLayer.Services;

public interface ITeacherServices
{
    void UpdateTeacherInfo(Teacher teacher, string firstName, string lastName, string email);
    void DisplayTeacherInfo(Teacher teacher);
    List<Course> GetAssignedCourses(Teacher teacher);
}
