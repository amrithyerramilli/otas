using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Interfaces;

namespace OTAS2.Repository.Repository
{
    public class RID_TABLERepository
    {
        Context context;
        public RID_TABLERepository()
            : this(new Context())
        {
        }
        public RID_TABLERepository(Context context)
        {
            this.context = context;
        }        
        public void InsertRecord(RID_TABLE record)
        {
            context.RID_TABLE.Add(record);
            Save();
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
