

using System;
namespace SIS.Entity;

// Define Course Class
public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }

        private List<Enrollment> enrollments = new List<Enrollment>();

        // Course Class Constructor
        public Course(int courseID, string courseName, string courseCode, string instructorName)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
        }

        // AssignTeacher Method
        public void AssignTeacher(Teacher teacher)
        {
            InstructorName = $"{teacher.FirstName} {teacher.LastName}";
            Console.WriteLine($"Teacher {InstructorName} assigned to course {CourseName}");
        }

        // UpdateCourseInfo Method
        public void UpdateCourseInfo(string courseCode, string courseName, string instructor)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            InstructorName = instructor;
            Console.WriteLine("Course information updated.");
        }

        // DisplayCourseInfo Method()
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"ID: {CourseID}, Course: {CourseName}, Code: {CourseCode}, Instructor: {InstructorName}");
        }


        // Get Enrollments
        public List<Enrollment> GetEnrollments()
        {
            return enrollments;
        }

        // Get Assigned Teacher
        public string GetTeacher()
        {
            return InstructorName;
        }
    }