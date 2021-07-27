using Labo.DAL;
using Labo.DAL.Entities;
using Labo.Models;
using Labo.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Services
{
    public class CentreService : RepositoryBase
    {
        public CentreService(DataContext dc) : base(dc)
        {
        }

        public IEnumerable<Centre> GetAll()
        {
            return _dc.Centres.ToList();
        }
        public Centre GetById(int id)
        {
            return _dc.Centres.SingleOrDefault(i => i.Id == id);
        }

        public PlanificationCentre Planification(int centreId)
        {
            Centre c = _dc.Centres.SingleOrDefault(i => i.Id == centreId);
            IEnumerable<LotVaccin> lotVaccins = _dc.LotVaccins.Where(l => l.CentreId == c.Id).Include("TypeVaccin");
            List<TypeVaccin> typeVaccins = new List<TypeVaccin>();

            foreach (var item in lotVaccins)
            {
                if (typeVaccins.Contains(item.TypeVaccin) == false) typeVaccins.Add(item.TypeVaccin);
            }

            PlanificationCentre p = new PlanificationCentre();
            p.Centre = c;
            p.CentreId = c.Id;
            p.TypeVaccins = typeVaccins;

            return p;
        } 

    }
}
