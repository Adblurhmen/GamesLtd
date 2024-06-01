using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamsIRep.IRepositry
{
    public interface IVenueRep
    {
        public IQueryable<Venue> GetAll();
        public Venue GetById(int id);
        public IQueryable<Venue> Sarche(string Name);
        public void Creat(Venue model);
        public void Update(Venue model);
        public void Delete(Venue model);
       
    }
}
