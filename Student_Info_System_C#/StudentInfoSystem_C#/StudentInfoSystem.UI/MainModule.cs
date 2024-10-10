using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Repository;
using StudentInfoSystem.BusinessLayer.Services;

namespace StudentInfoSystem.UI;

public class MainModule
{
    static void Main(string[] args)
    {


            IStudentRepository studentRepository = new StudentRepository();
            ICourseRepository courseRepository = new CourseRepository();

            // Task 8: Student Enrollment
            StudentRepository johnDoe = new StudentRepository(0, "John", "Doe", new DateTime(1995, 8, 15), "john.doe@example.com", "123-456-7890");
            studentRepository.AddStudent(johnDoe);
            List<CourseRepository> johnCourses = new List<CourseRepository>
            {
                new CourseRepository(0, "Introduction to Programming", "CS101", "TBD"),
                new CourseRepository(0, "Mathematics 101", "MATH101", "TBD")
            };

            foreach (var course in johnCourses)
            {
                courseRepository.AddCourse(course);
            }

            courseRepository.EnrollStudentInCourses(johnDoe, johnCourses);
            
            // Task 9: Teacher Assignment
            static void AssignTeacherToCourse()
            {
                ICourseRepository courseRepository = new CourseRepository();

                Course course = courseRepository.GetCourseById("CS302");
                courseRepository.AssignTeacherToCourse(course, "Sarah Smith");
            }


            // Task 10: Payment Record
            static void RecordPayment()
            {
                IStudentRepository studentRepository = new StudentRepository();

                Student jane = studentRepository.GetStudentById(101);
                PaymentRepository paymentRepository = new PaymentRepository();
                PaymentRepository payment = new PaymentRepository(0, jane.StudentID, 500m, DateTime.Now);
                
                paymentRepository.AddPayment(payment);
                Console.WriteLine("Payment recorded successfully.");
            }

            // Task 11: Enrollment Report Generation
            static void GenerateEnrollmentReport()
            {
                ICourseRepository courseRepository = new CourseRepository();
                Course course = courseRepository.GetCourseById("CS101");
                
                var enrollments = courseRepository.GetEnrollments(course);
                foreach (var enrollment in enrollments)
                {
                    Console.WriteLine($"Student ID: {enrollment.StudentID}, Enrollment Date: {enrollment.EnrollmentDate}");
                }
            }


            bool continueApp = true;

            while (continueApp)
        {
            Console.WriteLine("Student Information System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Enroll Student in Course");
            Console.WriteLine("4. Make Payment");
            Console.WriteLine("5. Assign Teacher to Course");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent(studentRepository);
                    break;

                case 2:
                    AddCourse(courseRepository);
                    break;

                case 3:
                    EnrollStudent(studentRepository, courseRepository);
                    break;

                case 4:
                    MakePayment(studentRepository);
                    break;

                case 5:
                    AssignTeacherToCourse(courseRepository);
                    break;

                case 6:
                    continueApp = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void AddStudent(IStudentRepository studentRepository)
    {
        Console.Write("Enter Student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        var student = new Student
        {
            StudentID = studentId,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dob,
            Email = email,
            PhoneNumber = phone
        };

        studentRepository.AddStudent(student);
        Console.WriteLine("Student added successfully.");
    }

    static void AddCourse(ICourseRepository courseRepository)
    {
        Console.Write("Enter Course ID: ");
        int courseId = int.Parse(Console.ReadLine());
        Console.Write("Enter Course Name: ");
        string courseName = Console.ReadLine();

        var course = new Course
        {
            CourseID = courseId,
            CourseName = courseName,
            
        };

        courseRepository.AddCourse(course);
        Console.WriteLine("Course added successfully.");
    }


    static void EnrollStudent(IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        Console.Write("Enter Student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter Course ID: ");
        string courseCode = (Console.ReadLine());

        var student = studentRepository.GetStudentById(studentId);
        var course = courseRepository.GetCourseById(courseCode);

        if (student != null && course != null)
        {
            studentRepository.EnrollInCourse(student,course);
            Console.WriteLine("Student enrolled successfully.");
        }
        else
        {
            Console.WriteLine("Student or Course not found.");
        }
    }


    static void MakePayment(IStudentRepository studentRepository)
    {
        Console.Write("Enter Student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter Payment Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        var student = studentRepository.GetStudentById(studentId);

        if (student != null)
        {
            studentRepository.MakePayment(student,amount, DateTime.Now);
            Console.WriteLine("Payment recorded successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void AssignTeacherToCourse(ICourseRepository courseRepository)
    {
        Console.Write("Enter Course ID: ");
        string courseCode = Console.ReadLine();
        Console.Write("Enter Teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());

        var course = courseRepository.GetCourseById(courseCode);

        if (course != null)
        {
            var teacher = new Teacher { TeacherID = teacherId };
            courseRepository.AssignTeacherToCourse(course,teacher);
            Console.WriteLine("Teacher assigned successfully.");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }


            


    }
