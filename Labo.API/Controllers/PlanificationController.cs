using Labo.Models;
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
    public class PlanificationController : ControllerBase
    {

        private readonly CentreService _serviceCentre;

        public PlanificationController(CentreService s)
        {
            _serviceCentre = s;
        }

        [HttpGet("{id:int}")]
        public ActionResult<PlanificationCentre> Get(int id)
        {
            try
            {
                PlanificationCentre result = _serviceCentre.Planification(id);
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

    }
}
