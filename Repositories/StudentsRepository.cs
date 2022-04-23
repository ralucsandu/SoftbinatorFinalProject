using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private FinalProjectContext db;

        public StudentsRepository(FinalProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Student> GetStudentsIQueryable()
        {
            var students = db.Students;
            return students;
        }

        public void CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();
        }

    }
}
