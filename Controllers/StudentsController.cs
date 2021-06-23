using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Potpis i opis metode
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() // IActionResult
        {
            try
            {
                var results = _studentRepository.AllStudents;
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
    }
}
