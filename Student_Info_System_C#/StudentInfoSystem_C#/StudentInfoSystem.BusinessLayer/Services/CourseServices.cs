using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.BusinessLayer.Repository;

namespace StudentInfoSystem.BusinessLayer.Services;

public class CourseServices : ICourseServices
{
    private readonly ICourseRepository _courseRepository;
    public CourseServices(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public void AssignTeacherToCourse(Course course, Teacher teacher)
    {
        _courseRepository.AssignTeacherToCourse(course, teacher);
    }

    public void UpdateCourseInfo(Course course, string courseCode, string courseName, string instructor)
    {
        _courseRepository.UpdateCourseInfo(course, courseCode, courseName, instructor);
    }

    public void DisplayCourseInfo(Course course)
    {
        _courseRepository.DisplayCourseInfo(course);
    }

    public List<Enrollment> GetEnrollments(Course course){
       return _courseRepository.GetEnrollments(course);
    }

    public Course GetCourseById(string courseCode){
        return _courseRepository.GetCourseById(courseCode);
    }

    public void AddCourse(Course course){
        _courseRepository.AddCourse(course);
    }

    public void EnrollStudentInCourses(Student student, List<Course> courses){
        _courseRepository.EnrollStudentInCourses(student,courses);
    }
}
