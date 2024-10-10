using System;

namespace StudentInfoSystem.Entity;

public class Teacher
{

     //Task 1 - Define Teacher Class
        public int TeacherID { get; set; }
        public String FirstName {  get; set; }
        public String LastName {  get; set; }
        public String Email {  get; set; }

        public List<Course> AssignedCourses { get; set; }

}
