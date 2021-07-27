using Labo.DAL;
using Labo.DAL.Entities;
using Labo.Services.Bases;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Services
{
    public class InjectionService : RepositoryBase
    {
        public InjectionService(DataContext dc) : base(dc)
        {
        }

        public IEnumerable<Injection> GetAll()
        {
            return _dc.Injections.ToList();
        }

        public Injection GetById(int id)
        {
            return _dc.Injections.SingleOrDefault(i => i.Id == id);
        }

        //Pour obtenir le résumé des injections pour le patient
        public IEnumerable<Injection> GetAllByPatient(int idPatient)
        {
            return _dc.Injections.Where(i => i.PatientId == idPatient).ToList();
        }


        //Non utile ici (géré en ASP MVC)
        public Injection Update(Injection entity)
        {
            Injection result = GetById(entity.Id);
            if(result != null)
            {
                result.PatientId = entity.PatientId;
                result.CalendrierHeureId = entity.CalendrierHeureId;
                result.LotVaccinId = entity.LotVaccinId;
                result.PersonnelId = entity.PersonnelId;

                _dc.SaveChanges();
            }
            return result;
        }

        //Création d'une injection avec l'heure et l'id du patient
        public Injection Insert(int idCalendrierHeure, int idPatient)
        {
            Injection injection = new Injection();
            injection.CalendrierHeureId = idCalendrierHeure;
            injection.PatientId = idPatient;


            _dc.Injections.Add(injection);
            _dc.SaveChanges();
            return injection;
        }
    }
}
