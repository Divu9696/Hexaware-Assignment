using System;

namespace StudentInfoSystem.Entity;

public class Enrollment
{
     //Task 1 - Define Enrollment Class
    public int EnrollmentID { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
    public DateTime EnrollmentDate {  get; set; }

    
}
