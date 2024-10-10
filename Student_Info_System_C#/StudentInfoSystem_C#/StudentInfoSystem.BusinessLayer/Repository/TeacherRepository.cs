using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer.Exceptions;

namespace StudentInfoSystem.BusinessLayer.Repository;


public class TeacherRepository : ITeacherRepository
{
    private List<Teacher> teachers = new List<Teacher>(); // In-memory storage for teachers

    Teacher t=new Teacher();
    public TeacherRepository(int teacherID, string firstName, string lastName, string email)
        {
            t.TeacherID = teacherID;
            t.FirstName = firstName;
            t.LastName = lastName;
            t.Email = email;
        }

        public void UpdateTeacherInfo(Teacher teacher, string firstName, string lastName, string email)
        {
            if (teacher == null)
                throw new TeacherNotFoundException("Teacher not found.");
            
            teacher.FirstName = firstName;
            teacher.LastName = lastName;
            teacher.Email = email;
            Console.WriteLine("Teacher information updated successfully.");
        }

        public void DisplayTeacherInfo(Teacher teacher)
        {
            if (teacher == null)
                throw new TeacherNotFoundException("Teacher not found.");
            
            Console.WriteLine($"Teacher Info: {teacher.FirstName} {teacher.LastName}, Email: {teacher.Email}");
        }

        public List<Course> GetAssignedCourses(Teacher teacher)
        {
            if (teacher == null)
                throw new TeacherNotFoundException("Teacher not found.");
            Console.WriteLine($"Retrieving courses for {teacher.FirstName} {teacher.LastName}");
            return teacher.AssignedCourses; // Return the assigned courses
        }
}
