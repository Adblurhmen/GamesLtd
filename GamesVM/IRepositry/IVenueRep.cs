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
        public Task<List<Venue>> GetAll();
        public Task<Venue> GetById(int id);
        public Task<List<Venue>> Sarche(string Name);
        public Task Creat(Venue model);
        public Task Update(Venue model);
        public Task Delete(Venue model);
       
    }
}
