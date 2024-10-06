
using System;
namespace SIS.Entity;

// Define Enrollment Class

public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // Enrollment Class Constructor
        public Enrollment(int enrollmentID, Student student, Course course, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentID;
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }

        public Student GetStudent()
        {
            return Student;
        }

        public Course GetCourse()
        {
            return Course;
        }
    }
    
