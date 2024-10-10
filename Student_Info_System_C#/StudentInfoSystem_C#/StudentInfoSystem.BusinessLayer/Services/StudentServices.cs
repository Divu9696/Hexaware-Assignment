using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.BusinessLayer.Repository;

namespace StudentInfoSystem.BusinessLayer.Services;

public class StudentServices : IStudentServices
{
    // private readonly IStudentRepository _studentRepository;

    IStudentRepository _studentRepository;

    public StudentServices(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void EnrollInCourse(Student student,Course course)
        {
            _studentRepository.EnrollInCourse(student,course);
        }

        public void UpdateStudentInfo(Student student,string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            _studentRepository.UpdateStudentInfo(student,firstName, lastName, dateOfBirth, email, phoneNumber);
        }

        public void DisplayStudentInfo(Student student)
        {
            _studentRepository.DisplayStudentInfo(student);
        }

        public void MakePayment(Student student,decimal amount, DateTime paymentDate)
        { //issue here in DateTime Parameter
            _studentRepository.MakePayment(student,amount, paymentDate);
        }

        public List<Course> GetEnrolledCourses(Student student)
        {
            return _studentRepository.GetEnrolledCourses(student);
        }

        public void GetPaymentHistory()
        {
            _studentRepository.GetPaymentHistory();
        }

        public void AddStudent(Student student){
            _studentRepository.AddStudent(student);
        }

}
