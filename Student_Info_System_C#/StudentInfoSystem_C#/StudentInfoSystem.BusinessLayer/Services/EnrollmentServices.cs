using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.BusinessLayer.Repository;

namespace StudentInfoSystem.BusinessLayer.Services;

public class EnrollmentServices : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    public EnrollmentServices(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        // Add a new enrollment
        public void AddEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.AddEnrollment(enrollment);
        }

        // Get the student associated with the enrollment
        public Student GetStudent(Enrollment enrollment, IStudentRepository studentRepository)
        {
            return _enrollmentRepository.GetStudent(enrollment.Student.StudentID, studentRepository);
        }

        // Get the course associated with the enrollment
        public Course GetCourse(Enrollment enrollment, ICourseRepository courseRepository)
        {
            return _enrollmentRepository.GetCourse(enrollment.CourseID, courseRepository);
        }
}
