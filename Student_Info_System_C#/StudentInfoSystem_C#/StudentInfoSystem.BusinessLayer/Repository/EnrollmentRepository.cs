using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Repository;
using StudentInfoSystem.BusinessLayer.Exceptions;

namespace StudentInfoSystem.BusinessLayer.Repository;

public class EnrollmentRepository : IEnrollmentRepository
    {
        Enrollment e = new Enrollment();
        
        
        public EnrollmentRepository(int enrollmentID, int studentID, int courseID, DateTime enrollmentDate)
        {
            e.EnrollmentID = enrollmentID;
            e.Student.StudentID = studentID;
            e.Course.CourseID = courseID;
            e.EnrollmentDate = enrollmentDate;
        }
        
        private List<Enrollment> enrollments = new List<Enrollment>(); // In-memory storage for enrollments

        // Add a new enrollment
        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
                throw new InvalidEnrollmentDataException("Invalid enrollment data.");
            
            enrollments.Add(enrollment);
            Console.WriteLine($"Added enrollment for Student ID {enrollment.StudentID} in Course ID {enrollment.CourseID}");
        }

        // Retrieve the associated student
        public Student GetStudent(int studentID, IStudentRepository studentRepository)
        {
            return studentRepository.GetStudentById(studentID);
        }

        // Retrieve the associated course
        public Course GetCourse(string courseCode, ICourseRepository courseRepository)
        {
            return courseRepository.GetCourseById(courseCode);
        }
    }
    