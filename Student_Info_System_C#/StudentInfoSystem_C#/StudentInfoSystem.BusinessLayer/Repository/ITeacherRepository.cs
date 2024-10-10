using System;
using System.Collections.Generic;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository;

public interface ITeacherRepository
{
    public void UpdateTeacherInfo(Teacher teacher, string firstName, string lastName, string email);
    
    public void DisplayTeacherInfo(Teacher teacher);
    
    public List<Course> GetAssignedCourses(Teacher teacher);
}
