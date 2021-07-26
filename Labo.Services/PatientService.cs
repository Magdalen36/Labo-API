using Labo.DAL;
using Labo.DAL.Entities;
using Labo.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Services
{
    public class PatientService : RepositoryBase
    {
        public PatientService(DataContext dc) : base(dc)
        {
        }

        //Faire toute la gestion de création de patient 

        public IEnumerable<Patient> GetAll()
        {
            return _dc.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _dc.Patients.SingleOrDefault(p => p.Id == id);
        }
    }
}
