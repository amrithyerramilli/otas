using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Interfaces;

namespace OTAS2.Repository.Repository
{
    public class SubCompRepository : ISubCombRepository
    {
        IContext context;
        public SubCompRepository()
            : this(new Context())
        {
        }
        public SubCompRepository(IContext context)
        {
            this.context = context;
        }
        public IList<SubComb> GetAllSubComb()
        {
            return context.SubComb.ToList();
        }
    }
}
