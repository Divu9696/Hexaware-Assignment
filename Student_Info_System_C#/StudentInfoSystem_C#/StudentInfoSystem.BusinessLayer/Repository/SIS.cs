using System;
using System.Collections.Generic;
using System.Linq;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Exceptions;
using StudentInfoSystem.BusinessLayer.Services;

namespace StudentInfoSystem.BusinessLayer.Repository;

public class SIS
{
    private List<Student> students = new List<Student>();
    private List<Course> courses = new List<Course>();
    private List<Teacher> teachers = new List<Teacher>();
    private List<Payment> payments = new List<Payment>();
    private List<Enrollment> enrollments = new List<Enrollment>();

    public void EnrollStudentInCourse(Student student, Course course)
    {
    if (student.Enrollments.Any(e => e.Course.CourseID == course.CourseID))
    {
        throw new DuplicateEnrollmentException("Student is already enrolled in this course.");
    }
    

    var enrollment = new Enrollment(1, student, course, DateTime.Now);
    student.Enrollments.Add(enrollment);
    course.Enrollments.Add(enrollment);
    }



    public List<Enrollment> GetEnrollmentsForStudent(Student student)
    {
        return enrollments.Where(e => e.Student == student).ToList();
    }

    public List<Course> GetCoursesForTeacher(Teacher teacher)
    {
        return courses.Where(c => c.Teacher == teacher).ToList();
    }

    // Assign Teacher to Course
    public void AssignTeacherToCourse(Teacher teacher, Course course)
    {
        if (!courses.Contains(course))
        {
            throw new Exception("Course not found in the system.");
        }
        teacher.AssignCourse(course);
    }

    // Generate Reports
    public void GenerateEnrollmentReport(Course course)
    {
        Console.WriteLine("Enrollment Report for Course: " + course.CourseName);
        foreach (var student in CourseRepository.GetEnrolledStudents())
        {
            student.DisplayStudentInfo();
        }
    }

    public void GeneratePaymentReport(StudentRepository student)
    {
        Console.WriteLine("Payment Report for Student: " + student.FirstName + " " + student.LastName);
        foreach (var payment in student.GetPaymentHistory())
        {
            Console.WriteLine("Amount: " + payment.Amount + ", Date: " + payment.PaymentDate);
        }
    }
    

}
