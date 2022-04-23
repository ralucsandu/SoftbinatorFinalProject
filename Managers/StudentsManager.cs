using FinalProject.Entities;
using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public class StudentsManager : IStudentsManager
    {
        private readonly IStudentsRepository studentsRepository;
        public StudentsManager(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public List<StudentModel> GetStudents()
        {
            var students = studentsRepository.GetStudentsIQueryable()
                .Select(x => new StudentModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();
            return students;
        }
        public List<int> GetStudentIdsList()
        {
            var students = studentsRepository.GetStudentsIQueryable();
            var idList = students.Select(x => x.Id)
                .ToList();
            return idList;
        }

        public Student GetStudentById(int id)
        {
            var student = studentsRepository.GetStudentsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return student;
        }

        public void CreateStudent(StudentModel studentModel)
        {
            var newStudent = new Student
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName
            };

            studentsRepository.CreateStudent(newStudent);
        }

        public void UpdateStudent(StudentModel studentModel)
        {
            var student = GetStudentById(studentModel.Id);
            student.FirstName = studentModel.FirstName;
            student.LastName = studentModel.LastName;
            studentsRepository.UpdateStudent(student);
        }

        public void DeleteStudent(int Id)
        {
            var student = GetStudentById(Id);
            studentsRepository.DeleteStudent(student);
        }

    }
}
