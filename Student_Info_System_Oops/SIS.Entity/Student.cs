
using System;
namespace SIS.Entity

{
    // Define Student Class
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        private List<Course> enrolledCourses = new List<Course>();
        private List<Payment> paymentHistory = new List<Payment>();

        // Student Class Constrcutor
        public Student(int studentID, string firstName, string lastName, DateTime dob, string email, string phoneNumber)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // EnrollInCourse Method
        public void EnrollInCourse(Course course)
        {
            Console.WriteLine($"{FirstName} {LastName} has been enrolled in {course.CourseName}");
        }

        // UpdateStudentInfo Method
        public void UpdateStudentInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Console.WriteLine("Student information updated.");
        }

        // MakePayment Method
        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            Console.WriteLine($"{FirstName} {LastName} has made a payment of {amount:C} on {paymentDate.ToShortDateString()}");
        }


        // DisplayStudentInfo Method
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"ID: {StudentID}, Name: {FirstName} {LastName}, DOB: {DateOfBirth.ToShortDateString()}, Email: {Email}, Phone: {PhoneNumber}");
        }

        // Get Enrolled Courses
        public List<Course> GetEnrolledCourses()
        {
            // Logic to retrieve courses
            return new List<Course>(); // Dummy return for now
        }

        // Get Payment History
        public List<Payment> GetPaymentHistory()
        {
            // Logic to retrieve payments
            return new List<Payment>(); // Dummy return for now
        }

        
    }

}
