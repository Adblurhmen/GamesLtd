using Games.Contaxt.Database;
using Games.Domain.Entity;
using GamsIRep.IRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRep.Repositry
{
    public class BookingRep : IBookingRep
    {
        private readonly GamesContext db;
        public BookingRep(GamesContext db)
        {
            this.db = db;

        }
        public void Creat(Booking model)
        {
            var data = db.bookings.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data==null)
            {
                db.bookings.Add(model);
                db.SaveChanges();

            }
        }

        public void Delete(Booking model)
        {
            var data = db.bookings.FirstOrDefault(a => a.Id == model.Id);
            if (data==null)
            {
                db.bookings.Remove(model);
                db.SaveChanges();
            }
        }

        public IQueryable<Booking> GetAll()
        {
            var data = db.bookings.Select(a => a);
            return data;
        }

        public Booking GetById(int id)
        {
            var data = db.bookings.FirstOrDefault(a => a.Id== id);
            return data;
        }

        

        public IQueryable<Booking> Sarche(int id)
        {
            var data = db.bookings.Where(a => a.Id==id);
            return data;
        }

        public void Update(Booking model)
        {
            var data = db.bookings.FirstOrDefault(db => db.Id == model.Id);
            if (data==null)
            {
                data.NumberHours=model.NumberHours;
                data.Prise=model.Prise;
                
                db.SaveChanges();

            }
        }
    }
}
