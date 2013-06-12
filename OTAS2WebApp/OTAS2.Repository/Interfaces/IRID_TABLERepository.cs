using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;

namespace OTAS2.Repository.Interfaces
{
    interface IRID_TABLERepository
    {
        void InsertRecord(RID_TABLE record);
    }
}
