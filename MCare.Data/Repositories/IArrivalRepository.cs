using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IArrivalRepository
    {

        IQueryable<Arrival> GetArrivals();
        Arrival GetArrivalById(int id);
        int AddArrival(Arrival arrival);
        bool UpdateArrival(int id, Arrival arrival);
        bool RemoveArrival(int id);
    }
}
