using Labo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Services.Bases
{
    public abstract class RepositoryBase
    {
        protected readonly DataContext _dc;

        public RepositoryBase(DataContext dc)
        {
            if (dc is null) throw new ArgumentNullException("DataContext must be not null");
            _dc = dc;
        }
    }
}
