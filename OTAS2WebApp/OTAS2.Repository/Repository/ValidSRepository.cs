using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Repository.Interfaces;
using OTAS2.Domain.Entities;

namespace OTAS2.Repository.Repository
{
    public class ValidSRepository : IValidSRepository
    {
        IContext context;
        public ValidSRepository()
            : this(new Context())
        {
        }
        public ValidSRepository(IContext context)
        {
            this.context = context;
        }
        public IList<ValidS> GetAllValidS()
        {
            return context.ValidS.ToList();
        }
    }
}
