using System;
using System.Collections.Generic;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository;

public interface IEnrollmentRepository
{
    public void AddEnrollment(Enrollment enrollment);
    public Student GetStudent(int studentID, IStudentRepository studentRepository);
    public Course GetCourse(int courseID, ICourseRepository courseRepository);
}
