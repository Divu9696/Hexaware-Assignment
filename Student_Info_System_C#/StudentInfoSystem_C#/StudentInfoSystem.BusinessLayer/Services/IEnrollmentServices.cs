using System;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.BusinessLayer.Repository;
namespace StudentInfoSystem.BusinessLayer.Services;

public interface IEnrollmentService
{
    void AddEnrollment(Enrollment enrollment);
    Student GetStudent(int studentID, IStudentRepository studentRepository);
    Course GetCourse(int courseID, ICourseRepository courseRepository);
    
}
