using Labo.DAL.Entities;
using Labo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionController : ControllerBase
    {
        private readonly InjectionService _service;

        public InjectionController(InjectionService s)
        {
            _service = s;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<IEnumerable<Injection>> Get()   //GetAll
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Get",
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Injection> Get(int id)   //GetById
        {
            try
            {
                Injection result = _service.GetById(id);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Get",
                    Message = ex.Message
                });
            }
        }

        [HttpGet("[action]{id:int}")]
        public ActionResult<IEnumerable<Injection>> GetByPatient(int id)   //GetAll by Patient
        {
            try
            {
                return Ok(_service.GetAllByPatient(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Get",
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Injection> Put(int id, [FromBody] Injection injection)
        {
            try
            {
                if (injection is null) return BadRequest();
                if (id != injection.Id) return BadRequest();
                Injection result = _service.Update(injection);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Put",
                    Message = ex.Message
                });
            }
        }

    }
}
