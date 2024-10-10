using System;
using System.Collections.Generic;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository;

public interface ICourseRepository
{
       
        public void AssignTeacherToCourse(Course course, Teacher teacher);
        
        public void UpdateCourseInfo(Course course, string courseCode, string courseName, string instructor);
        
        public void DisplayCourseInfo(Course course);
        public List<Enrollment> GetEnrollments(Course course);

        public List<Student> getEnrolledStudents(Course course);
        public void GetTeacher();
        public Course GetCourseById(string courseCode);
        public void AddCourse(Course course);

        public void EnrollStudentInCourses(Student student, List<Course> courses);

}
