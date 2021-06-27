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
    [Route("api/students/{studentId}/[controller]")]
    [ApiController]
    public class FinalsController : ControllerBase
    {
        private readonly IFinalRepository _finalRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public FinalsController(IFinalRepository finalRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _finalRepository = finalRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<FinalModel>> Get(int studentId)
        {
            try
            {
                List<FinalModel> result = new List<FinalModel>();
                var finals = _finalRepository.GetFinalsByStudentId(studentId);
                result = _mapper.Map<List<FinalModel>>(finals);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<FinalModel> Get(int studentId, int id)
        {
            try
            {
                FinalModel result = new FinalModel();
                var final = _finalRepository.GetFinalByStudentId(studentId, id);
                if (final == null)
                {
                    return NotFound();
                }
                result = _mapper.Map<FinalModel>(final);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpPost]
        public ActionResult<FinalModel> Post(int studentId, FinalModel final)
        {
            try
            {
                var finalEntry = _mapper.Map<Final>(final);
                finalEntry.StudentId = studentId;
                var newFinal = _finalRepository.AddFinal(finalEntry);
                var result = _mapper.Map<FinalModel>(newFinal);
                var url = _linkGenerator.GetPathByAction(HttpContext, "Get", values: new { studentId, id = result.Id });
                return Created(url, result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpPut]
        public ActionResult<FinalModel> Put(int studentId, int id, FinalModel final)
        {
            try
            {
                /*
                 * todo: provera da li postoji studentid, finalid
                 * u UpdateFinal() metodi moze da se koristi maper umesto rucnog premapiranja
                 * Ukoliko ne zelimo da "pregazimo" vezne objekte, mozemo da postavimo .ForMember(f => f.Student, opt=>opt.Ignore());
                 * */
                var finalDomainModel = _mapper.Map<Final>(final);
                var updatedFinal = _finalRepository.UpdateFinal(finalDomainModel);
                var result = _mapper.Map<FinalModel>(updatedFinal);

                return result;
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int studentId, int id)
        {
            try
            {
                var final = _finalRepository.GetFinalByStudentId(studentId, id);
                if (final == null)
                {
                    return NotFound();
                }

                _finalRepository.DeleteFinal(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }
    }
}
