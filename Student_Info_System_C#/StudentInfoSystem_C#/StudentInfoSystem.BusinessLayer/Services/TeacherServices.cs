using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using StudentInfoSystem.BusinessLayer.Repository;

namespace StudentInfoSystem.BusinessLayer.Services;

public class TeacherServices : ITeacherServices
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherServices(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void UpdateTeacherInfo(Teacher teacher, string firstName, string lastName, string email)
        {
            _teacherRepository.UpdateTeacherInfo(teacher, firstName, lastName, email);
        }

        public void DisplayTeacherInfo(Teacher teacher)
        {
            _teacherRepository.DisplayTeacherInfo(teacher);
        }

        public List<Course> GetAssignedCourses(Teacher teacher)
        {
            return _teacherRepository.GetAssignedCourses(teacher);
        }
}

