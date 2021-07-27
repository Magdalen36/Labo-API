using Labo.DAL.Entities;
using Labo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.API.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientController(PatientService ps)
        {
            _service = ps;
        }


        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
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
        public ActionResult<Patient> Get(int id)
        {
            try
            {
                Patient result = _service.GetById(id);
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


        //PAS BON !
        //Faire un modèle intermédiaire (plusieurs, car adresse ?) 

        [HttpPost]
        public ActionResult<Patient> Post([FromForm] Patient patient) 
        {
            try
            {
                if (patient is null) return BadRequest();
                Patient result = _service.Insert(patient);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Post",
                    Message = ex.Message
                });
            }
        }
        
    }
}
