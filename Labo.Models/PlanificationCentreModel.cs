using Labo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Models
{
    public class PlanificationCentreModel
    {
        public int Id { get; set; }
        public int CentreId { get; set; }
        public string CentreName { get; set; }


        public List<string> TypeVaccins { get; set; }

        //public CalendrierJour CalendrierJour { get; set; }
        //public int CalendrierJourId { get; set; }

        //public CalendrierHeure CalendrierHeure { get; set; }
        //public int CalendrierHeureId { get; set; }

    }
}
