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

        
    }
}
