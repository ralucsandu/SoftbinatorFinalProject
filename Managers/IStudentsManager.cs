using FinalProject.Entities;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public interface IStudentsManager
    {
        List<StudentModel> GetStudents();
        List<int> GetStudentIdsList();
        Student GetStudentById(int id);
        void CreateStudent(StudentModel studentModel);
        void UpdateStudent(StudentModel studentModel);
        void DeleteStudent(int StudentId);

    }
}