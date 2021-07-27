using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Models
{
    public class PlanificationCalendrierModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Jour { get; set; }


    }
}
