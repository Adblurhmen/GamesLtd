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
        public Task <List <Booking> >GetAll();
        public Task <Booking> GetById(int id);
        public Task<List<Booking>> Sarche(Booking booking);
        public Task Creat( Booking model);
        public Task Update(Booking model);
        public Task Delete(Booking model);
    }
}
