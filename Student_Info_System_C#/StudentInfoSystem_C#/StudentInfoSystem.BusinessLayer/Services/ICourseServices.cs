using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
namespace StudentInfoSystem.BusinessLayer.Services;

public interface ICourseServices
{
//    void AssignTeacher(Teacher teacher);
//     void UpdateCourseInfo(string courseCode, string courseName, string instructor);
//     void DisplayCourseInfo();
//     void GetEnrollments();
//     void GetTeacher();
    void AssignTeacherToCourse(Course course, Teacher teacher);
    void UpdateCourseInfo(Course course, string courseCode, string courseName, string instructor);
    List<Enrollment> GetEnrollments(Course course);
    void DisplayCourseInfo(Course course);
        // void GetTeacher();
    public Course GetCourseById(string courseCode);

    public void AddCourse(Course course);
    public void EnrollStudentInCourses(Student student, List<Course> courses);
}
