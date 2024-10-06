

using System;
namespace SIS.Entity;


// define Teacher Class
public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private List<Course> assignedCourses = new List<Course>();

        // Teacher Class Constructor
        public Teacher(int teacherID, string firstName, string lastName, string email)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Update Teacher Information
        public void UpdateTeacherInfo(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Console.WriteLine("Teacher information updated.");
        }

        // Get Assigned Courses
        public List<Course> GetAssignedCourses()
        {
            // Logic to retrieve courses
            return new List<Course>(); // Dummy return for now
        }

        // Display Teacher Info
        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"ID: {TeacherID}, Name: {FirstName} {LastName}, Email: {Email}");
        }

    }