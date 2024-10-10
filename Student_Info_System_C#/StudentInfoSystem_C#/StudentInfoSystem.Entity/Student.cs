using System;
using System.Collections.Generic;

namespace StudentInfoSystem.Entity;

public class Student
{
     //Task 1 - Define Student Class
    public int StudentID {  get; set; }
    public string FirstName {  get; set; }
    public string LastName {  get; set; }
    public DateTime DateOfBirth {  get; set; }
    public string Email {  get; set; }
    public string PhoneNumber {  get; set; }

    public List<Enrollment> Enrollments { get; set; }
    

}
