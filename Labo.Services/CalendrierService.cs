using Labo.DAL;
using Labo.DAL.Entities;
using Labo.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Services
{
    public class CalendrierService : RepositoryBase
    {
        public CalendrierService(DataContext dc) : base(dc)
        {
        }

        public IEnumerable<CalendrierJour> GetAll()
        {
            return _dc.CalendrierJours.ToList();
        }

        public CalendrierJour GetById(int id)
        {
            return _dc.CalendrierJours.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<CalendrierJour> GetAllByCentre(int idCentre)
        {
            return _dc.CalendrierJours.Where(i => i.CentreId == idCentre);
        }
        
        public IEnumerable<CalendrierHeure> GetAllByJour(int idJour)
        {
            return _dc.CalendrierHeures.Where(i => i.CalendrierJourId == idJour);
        }


    }
}
