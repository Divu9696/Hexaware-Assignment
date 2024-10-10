using System;
using System.Linq;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Exceptions;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using StudentInfoSystem.BusinessLayer.Util;

namespace StudentInfoSystem.BusinessLayer.Repository;

    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>(); // In-memory storage for students

        Student s = new Student();
        Payment p = new Payment();
        Course c = new Course();

        public StudentRepository(){

        }

    
        public StudentRepository(int id, string first_name, string last_name, string DOB, string email, string phone_num)
        {
            s.StudentID=id;
            s.FirstName = first_name;
            s.LastName = last_name;
            s.DateOfBirth = Convert.ToDateTime( DOB);
            s.Email = email;
            s.PhoneNumber = phone_num;
        }

         public void DisplayStudentInfo(Student student)
        {
            if (student == null)
                throw new StudentNotFoundException("Student not found.");
            
            Console.WriteLine("Displaying Student Information:");
            Console.WriteLine($"Student Info: {student.FirstName} {student.LastName}, Email: {student.Email}, Phone: {student.PhoneNumber}");
        }

        public void EnrollInCourse(Student student, Course course)
        {
            if (student == null || course == null)
                throw new InvalidEnrollmentDataException("Invalid student or course data.");
            
            
            
            EnrollmentRepository enrollment = new EnrollmentRepository(0, student.StudentID, course.CourseID, DateTime.Now);
            student.Enrollments.Add(enrollment);
            Console.WriteLine($"Enrolling {student.FirstName} {student.LastName} in {course.CourseName}");
            
        }

        public void UpdateStudentInfo(Student student, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            if (student == null)
                throw new StudentNotFoundException("Student not found.");
            
            student.FirstName = firstName;
            student.LastName = lastName;
            student.DateOfBirth = dateOfBirth;
            student.Email = email;
            student.PhoneNumber = phoneNumber;
            Console.WriteLine("Student information updated successfully.");
        }

        public List<Course> GetEnrolledCourses(Student student)
        {
            // This method retrieves the courses a student is enrolled in
            Console.WriteLine($"Retrieving courses for {student.FirstName} {student.LastName}");
            List<Course> enrolledCourses = new List<Course>();
            foreach (var enrollment in student.Enrollments)
            {
                enrolledCourses.Add(new CourseRepository(enrollment.CourseID, "Dummy Course", "CODE123", "Instructor Name"));
            }
            return enrolledCourses;
        }

        public void MakePayment(Student student, decimal amount, DateTime paymentDate)
        {
            if (student == null)
                throw new StudentNotFoundException("Student not found.");
            
            if (amount <= 0)
            {
            throw new PaymentValidationException("Payment amount must be greater than zero.");
            }
            PaymentRepository payment = new PaymentRepository(0, student.StudentID, amount, paymentDate);
            student.Payments.Add(payment);
            Console.WriteLine($"Payment of {amount:C} made by {student.FirstName} {student.LastName}");
            
        }

        // public void GetPaymentHistory()
        // {
        //     Console.WriteLine($"Payment Details of Student: {p.PaymentID},{p.StudentID},{p.Amount},{p.PaymentDate}");
        // }
        public List<Payment> GetPaymentHistory()
        {
        return payments;
        }
        
        public Student GetStudentById(int studentID)
        {
            using (SqlConnection conn = DBConnectionUtil.GetConnection())
            {
                string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Student(
                            (int)reader["StudentID"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (DateTime)reader["DateOfBirth"],
                            (string)reader["Email"],
                            (string)reader["PhoneNumber"]
                        );
                    }
                    else
                    {
                        throw new Exception("Student not found.");
                    }
                }
            }
            
        }


        public void AddStudent(Student student)
        {
            using (SqlConnection conn = DBConnectionUtil.GetConnection())
            {
                string query = "INSERT INTO Students (FirstName, LastName, DateOfBirth, Email, PhoneNumber) " +
                            "VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @PhoneNumber)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Student added successfully.");
                }
            }
        }
    }

