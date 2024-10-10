using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
namespace StudentInfoSystem.BusinessLayer.Services;

public interface IStudentServices
{
    // void AddStudent(Student student);
    public void UpdateStudentInfo(Student student, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);
    public void EnrollInCourse(Student student, Course course);
    public void MakePayment(Student student, decimal amount, DateTime paymentDate);
    public void DisplayStudentInfo(Student student);
    // Student GetStudentById(int studentID); // New method
    public List<Course> GetEnrolledCourses(Student student);
    public void GetPaymentHistory();
    public void AddStudent(Student student);


    
}
    
