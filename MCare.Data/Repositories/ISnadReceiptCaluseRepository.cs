using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ISnadReceiptCaluseRepository 
    {
        IQueryable<SnadReceiptCaluse> GetSnadReceiptCaluses();
        SnadReceiptCaluse GetSnadReceiptCaluseById(int id);
    }
}
