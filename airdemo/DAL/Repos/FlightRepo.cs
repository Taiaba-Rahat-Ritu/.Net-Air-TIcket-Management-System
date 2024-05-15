using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FlightRepo : Repo, IRepo<Flight, int, bool>
    {
        public bool Create(Flight obj)
        {
            db.Flights.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Flights.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Flight> Get()
        {
            return db.Flights.ToList();
        }

        public Flight Get(int id)
        {
            return db.Flights.Find(id);
        }

        public bool Update(Flight obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
