using System;
using System.Linq;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Exceptions;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using StudentInfoSystem.BusinessLayer.Util;

namespace StudentInfoSystem.BusinessLayer.Repository;

public class CourseRepository : ICourseRepository
{
    private List<Course> courses = new List<Course>(); // In-memory storage for courses

    public CourseRepository(){

    }
    Course c=new Course();
    public CourseRepository(int courseID, string courseName, string courseCode, string instructorName)
        {
            c.CourseID = courseID;
            c.CourseName = courseName;
            c.CourseCode = courseCode;
            c.InstructorName = instructorName;
        }

        public void AssignTeacherToCourse(Course course, Teacher teacher)
        {
            if (course == null || teacher == null)
                throw new InvalidCourseDataException("Invalid course or teacher data.");
            
            course.InstructorName = $"{teacher.FirstName} {teacher.LastName}";
            teacher.AssignedCourses.Add(course);
            Console.WriteLine($"Assigned {teacher.FirstName} {teacher.LastName} to course {course.CourseName}");
        }

        public void UpdateCourseInfo(Course course, string courseCode, string courseName, string instructor)
        {
            if (course == null)
                throw new CourseNotFoundException("Course not found.");
            
            course.CourseCode = courseCode;
            course.CourseName = courseName;
            course.InstructorName = instructor;
            Console.WriteLine("Course information updated successfully.");
        }

        public List<Enrollment> GetEnrollments(Course course)
        {
            if (course == null)
                throw new CourseNotFoundException("Course not found.");
            Console.WriteLine($"Retrieving enrollments for {course.CourseName}");
            return course.Enrollments;
            
        }

        public void DisplayCourseInfo(Course course)
        {
            if (course == null)
                throw new CourseNotFoundException("Course not found.");

            Console.WriteLine($"Course Info: {course.CourseName}, Code: {course.CourseCode}, Instructor: {course.InstructorName}");
            // Console.WriteLine($"Course Info: {course.CourseName} (Code: {course.CourseCode}), Instructor: {course.InstructorName}");
        }

        public Teacher GetTeacher()
        {
            return new Teacher(1, c.InstructorName, "", "teacher@example.com"); // Placeholder
        }
        
        public Course GetCourseById(string courseCode)
        {
            var course = courses.Find(c => c.CourseCode == courseCode);
            if (course == null)
            {
                throw new CourseNotFoundException("Course not found");
            }
            return course;
            
        }
        public List<Student> GetEnrolledStudents(Course course)
        {
        return course.enrolledStudents;
        }
        public Course GetCourseByCode(string courseCode)
        {
            using (SqlConnection conn = DBConnectionUtil.GetConnection())
            {
                string query = "SELECT * FROM Courses WHERE courseCode = @courseCode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseCode", courseCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new CourseRepository(
                            (int)reader["CourseID"],
                            (string)reader["CourseName"],
                            (string)reader["CourseCode"],
                            (string)reader["InstructorName"]
                        );
                    }
                    else
                    {
                        throw new Exception("Course not found.");
                    }
                }
            }
        }


        public void AddCourse(Course course)
        {
            using (SqlConnection conn = DBConnectionUtil.GetConnection())
            {
                string query = "INSERT INTO Courses (CourseName, CourseCode, InstructorName) " +
                               "VALUES (@CourseName, @CourseCode, @InstructorName)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                    cmd.Parameters.AddWithValue("@InstructorName", course.InstructorName);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Course added to database.");
                }
            }
        }

        public void EnrollStudentInCourses(Student student, List<Course> courses)
        {
            using (SqlConnection conn = DBConnectionUtil.GetConnection())
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (var course in courses)
                    {
                        string query = "INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate) " +
                                    "VALUES (@StudentID, @CourseID, @EnrollmentDate)";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                            cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                            cmd.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    Console.WriteLine("Enrollment completed successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Transaction failed: {ex.Message}");
                }
            }
}
    
    
    }

