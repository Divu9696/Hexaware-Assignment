using System;

namespace StudentInfoSystem.Entity;

public class Course
{
     //Task 1 - Define Course Class
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public string InstructorName { get; set; }

    public Teacher AssignedTeacher { get; set; }

    public List<Enrollment> Enrollments { get; set; }

}