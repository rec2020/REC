using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ArrivalRepository : IArrivalRepository
    {
        private NajmetAlraqeeContext _context;

        public ArrivalRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddArrival(Arrival arrival)
        {
            _context.Arrivals.Add(arrival);
            _context.SaveChanges();

            return arrival.Id;
        }

        public Arrival GetArrivalById(int id)
        {
            return _context.Arrivals.Find(id);
        }

        public IQueryable<Arrival> GetArrivals()
        {
            return _context.Arrivals;
        }

        public bool RemoveArrival(int id)
        {
            var arrival = _context.Arrivals.SingleOrDefault(x => x.Id == id);
            if (arrival == null)
                return false;

            _context.Arrivals.Remove(arrival);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateArrival(int id, Arrival arrival)
        {
            Arrival existarrival = GetArrivalById(id);
            if (existarrival == null)
                return false;
            
            existarrival.Name = arrival.Name;
            existarrival.Country = arrival.Country;
            _context.Update(existarrival);
            _context.SaveChanges();

            return true;
        }
    }
}
