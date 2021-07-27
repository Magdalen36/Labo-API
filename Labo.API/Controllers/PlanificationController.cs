using Labo.DAL.Entities;
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
        private readonly CalendrierService _serviceCalendrier;
        private readonly InjectionService _serviceInjection;

        public PlanificationController(CentreService s, CalendrierService c, InjectionService i)
        {
            _serviceCentre = s;
            _serviceCalendrier = c;
            _serviceInjection = i;
        }


        //Les détails des centres, via l'id du centre
        [HttpGet("[Action]{id:int}")]
        public ActionResult<PlanificationCentreModel> GetInfoByCentre(int id)
        {
            try
            {
                PlanificationCentreModel result = _serviceCentre.PlanificationCentre(id);
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

        //La liste des jours disponibles, via l'id du centre choisi
        //Encore à gérer la la possibilité que les jours soient complets 
        [HttpGet("[action]{id:int}")]
        public ActionResult<IEnumerable<CalendrierJour>> GetCalendrierByCentre(int id)  
        {
            try
            {
                return Ok(_serviceCalendrier.GetAllByCentre(id));
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

        //La liste des heures disponibles, via l'id du jour choisi
        //Encore à gérer la la possibilité que les heures soient complètes 
        [HttpGet("[action]{id:int}")]
        public ActionResult<IEnumerable<CalendrierHeure>> GetCalendrierHeureByJour(int id) 
        {
            try
            {
                return Ok(_serviceCalendrier.GetAllByJour(id));
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

        //Insertion de l'injection
        [HttpPost]
        public ActionResult<Injection> Post(int idH, int idP)
        {
            try
            {
                if (idH == 0 || idP ==0) return BadRequest();
                Injection result = _serviceInjection.Insert(idH, idP);
                return CreatedAtAction(nameof(GetInfoByCentre), new { id = result.Id }, result);
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
