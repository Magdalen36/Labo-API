using Labo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Models
{
    public class PlanificationCentre
    {
        public int Id { get; set; }
        public Centre Centre { get; set; }
        public int CentreId { get; set; }

        public List<TypeVaccin> TypeVaccins { get; set; }

        //public CalendrierJour CalendrierJour { get; set; }
        //public int CalendrierJourId { get; set; }

        //public CalendrierHeure CalendrierHeure { get; set; }
        //public int  CalendrierHeureId { get; set; }

    }
}
