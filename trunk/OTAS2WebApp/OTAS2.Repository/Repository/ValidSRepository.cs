using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Repository.Interfaces;
using OTAS2.Domain.Entities;
using System.Data;

namespace OTAS2.Repository.Repository
{
    public class ValidSRepository : IValidSRepository
    {
        Context context;
        public ValidSRepository()
            : this(new Context())
        {
        }
        public ValidSRepository(Context context)
        {
            this.context = context;
        }
        public IList<ValidS> GetAllValidS()
        {
            return context.ValidS.ToList();
        }
        public void UpdateCounter(ValidS record)
        {
            context.Entry(record).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
