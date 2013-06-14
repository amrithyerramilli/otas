using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Interfaces;

namespace OTAS2.Repository.Repository
{
    public class FeedbackRepository
    {
        Context context;
        public FeedbackRepository()
            : this(new Context())
        {
        }
        public FeedbackRepository(Context context)
        {
            this.context = context;
        }
        public void InsertRecord(Feedback record)
        {
            context.Feedback.Add(record);
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
