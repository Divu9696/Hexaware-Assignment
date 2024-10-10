using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using System.Data.SqlClient;

namespace StudentInfoSystem.BusinessLayer.Util;

public class DatabaseInitializer
{
    private string connectionString;

    public DatabaseInitializer(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void InitializeDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create Students table
            string createStudentsTable = @"
                CREATE TABLE IF NOT EXISTS Students (
                    StudentId INT PRIMARY KEY IDENTITY(1,1),
                    FirstName NVARCHAR(50),
                    LastName NVARCHAR(50),
                    DateOfBirth DATE,
                    Email NVARCHAR(100),
                    PhoneNumber NVARCHAR(15)
                )";

            // Create Courses table
            string createCoursesTable = @"
                CREATE TABLE IF NOT EXISTS Courses (
                    CourseId INT PRIMARY KEY IDENTITY(1,1),
                    CourseName NVARCHAR(100),
                    CourseCode NVARCHAR(50)
                )";

            // Create Enrollments table
            string createEnrollmentsTable = @"
                CREATE TABLE IF NOT EXISTS Enrollments (
                    EnrollmentId INT PRIMARY KEY IDENTITY(1,1),
                    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
                    CourseId INT FOREIGN KEY REFERENCES Courses(CourseId),
                    EnrollmentDate DATE
                )";

            // Create Teachers table
            string createTeachersTable = @"
                CREATE TABLE IF NOT EXISTS Teachers (
                    TeacherId INT PRIMARY KEY IDENTITY(1,1),
                    FirstName NVARCHAR(50),
                    LastName NVARCHAR(50),
                    Email NVARCHAR(100),
                    Expertise NVARCHAR(100)
                )";

            // Create Payments table
            string createPaymentsTable = @"
                CREATE TABLE IF NOT EXISTS Payments (
                    PaymentId INT PRIMARY KEY IDENTITY(1,1),
                    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
                    Amount DECIMAL(18, 2),
                    PaymentDate DATE
                )";

            // Execute table creation commands
            using (SqlCommand command = new SqlCommand(createStudentsTable, connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqlCommand command = new SqlCommand(createCoursesTable, connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqlCommand command = new SqlCommand(createEnrollmentsTable, connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqlCommand command = new SqlCommand(createTeachersTable, connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqlCommand command = new SqlCommand(createPaymentsTable, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Database initialized successfully.");
        }
    }
}

// Data Retrieval
public class DataRetriever
{
    private string connectionString;

    public DataRetriever(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Retrieve a student by ID
    public Student GetStudent(int studentId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Students WHERE StudentId = @StudentId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentId", studentId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student(
                            (int)reader["StudentId"],
                            reader["FirstName"].ToString(),
                            reader["LastName"].ToString(),
                            reader["DateOfBirth"].ToString(),
                            reader["Email"].ToString(),
                            reader["PhoneNumber"].ToString());
                    }
                }
            }
        }

        return null; // Student not found
    }

    // Retrieve all courses
    public List<Course> GetAllCourses()
    {
        List<Course> courses = new List<Course>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Courses";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course(
                            (int)reader["CourseId"],
                            reader["CourseName"].ToString(),
                            reader["CourseCode"].ToString()));
                    }
                }
            }
        }
        return courses;
    }
}

// Data Insertion & Update
public class DataInserter
{
    private string connectionString;

    public DataInserter(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Insert a new student
    public void InsertStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = @"
                INSERT INTO Students (FirstName, LastName, DateOfBirth, Email, PhoneNumber)
                VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @PhoneNumber)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                command.ExecuteNonQuery();
            }
        }
    }

    // Update an existing student
    public void UpdateStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = @"
                UPDATE Students
                SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Email = @Email, PhoneNumber = @PhoneNumber
                WHERE StudentId = @StudentId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentId", student.StudentId);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                command.ExecuteNonQuery();
            }
        }
    }
}

// Transaction Management
public class TransactionManager
{
    private string connectionString;

    public TransactionManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void EnrollStudentInCourse(Student student, Course course)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    // Insert enrollment record
                    string enrollQuery = @"
                        INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate)
                        VALUES (@StudentId, @CourseId, @EnrollmentDate)";

                    using (SqlCommand command = new SqlCommand(enrollQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentId", student.StudentId);
                        command.Parameters.AddWithValue("@CourseId", course.CourseId);
                        command.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);
                        command.ExecuteNonQuery();
                    }

                    // Optionally update other related records (like payment) here

                    transaction.Commit();
                    Console.WriteLine("Enrollment transaction completed successfully.");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    Console.WriteLine("Enrollment transaction failed. Rolled back.");
                }
            }
        }
    }
}

// Dynamic Query Builder
public class DynamicQueryBuilder
{
    private string connectionString;

    public DynamicQueryBuilder(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void ExecuteCustomQuery(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void ExecuteParameterizedQuery(string baseQuery, Dictionary<string, object> parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(baseQuery, connection))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                command.ExecuteNonQuery();
            }
        }
    }
}