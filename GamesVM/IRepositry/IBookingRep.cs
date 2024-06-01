using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamsIRep.IRepositry
{
    public interface IBookingRep
    {
        public IQueryable<Booking> GetAll();
        public Booking GetById(int id);
        public IQueryable<Booking> Sarche(int id);
        public void Creat( Booking model);
        public void Update(Booking model);
        public void Delete(Booking model);
    }
}
