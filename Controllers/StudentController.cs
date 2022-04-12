using FinalProject.Entities;
using FinalProject.Managers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsManager manager;
        public StudentController(IStudentsManager studentsManager)
        {
            this.manager = studentsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = manager.GetStudents();
            return Ok(students);
        }

        [HttpGet("select-id")]
        public async Task<IActionResult> GetStudentIds()
        {
            var idList = manager.GetStudentIdsList();
            return Ok(idList);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = manager.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel studentModel)
        {
            manager.CreateStudent(studentModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentModel studentModel)
        {
            manager.UpdateStudent(studentModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            manager.DeleteStudent(id);
            return Ok();
        }
    }
}