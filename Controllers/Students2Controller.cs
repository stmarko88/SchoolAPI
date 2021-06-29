using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SchoolAPI.Data;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/v{version:apiVersion}/students")]
    [ApiVersion("2.0")]
    [ApiController]
    public class Students2Controller : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public Students2Controller(IStudentRepository studentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Potpis i opis metode
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int? departmentId) // IActionResult
        {
            try
            {
                var results = _studentRepository.AllStudents;
                if (departmentId.HasValue)
                {
                    results = _studentRepository.AllStudents.Where(s => s.DepartmentId == departmentId);
                }
                List<StudentModel> students = _mapper.Map<List<StudentModel>>(results);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpGet("id:int")]
        public ActionResult<StudentModel> Get(int id) // IActionResult
        {
            try
            {
                var result = _studentRepository.GetStudentById(id);
                if (result == null)
                {
                    return NotFound();
                }
                StudentModel student = _mapper.Map<StudentModel>(result);
                return student;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpPost]
        public IActionResult Post(StudentModel student)
        {
            try
            {
                var studentDomainModel = _mapper.Map<Student>(student);
                var newStudent = _studentRepository.AddStudent(studentDomainModel);
                var result = _mapper.Map<StudentModel>(newStudent);

                var location = _linkGenerator.GetPathByAction("Get", "Students", new { id = result.Id });
                return Created(location, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<StudentModel> Put(int id, StudentModel student)
        {
            try
            {
                var studentDomainModel = _mapper.Map<Student>(student);
                var updatedStudent = _studentRepository.UpdateStudent(studentDomainModel);
                var result = _mapper.Map<StudentModel>(updatedStudent);

                return result;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<StudentModel> Delete(int id)
        {
            try
            {
                bool success = _studentRepository.DeleteStudent(id);

                if (success)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }

            return BadRequest();
        }
    }
}
