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

        public PlanificationCentreModel PlanificationCentre(int centreId)
        {
            Centre c = _dc.Centres.SingleOrDefault(i => i.Id == centreId);
            IEnumerable<LotVaccin> lotVaccins = _dc.LotVaccins.Where(l => l.CentreId == c.Id).Include("TypeVaccin");
            List<string> typeVaccins = new List<string>();

            foreach (var item in lotVaccins)
            {
                if (typeVaccins.Contains(item.TypeVaccin.Name) == false) typeVaccins.Add(item.TypeVaccin.Name);
            }

            PlanificationCentreModel p = new PlanificationCentreModel();
            p.CentreId = c.Id;
            p.CentreName = c.Name;
            p.TypeVaccins = typeVaccins;

            return p;
        } 

    }
}
