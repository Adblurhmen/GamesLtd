using Games.Contaxt.Database;
using Games.Domain.Entity;
using GamsIRep.IRepositry;
using Microsoft.EntityFrameworkCore;
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
        public async Task Creat(Booking model)
        {
            var data = db.bookings.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data==null)
            {
                db.bookings.Add(model);
                db.SaveChanges();

            }
        }

        public async Task Delete(Booking model)
        {
            var data = db.bookings.FirstOrDefault(a => a.Id == model.Id);
            if (data==null)
            {
                db.bookings.Remove(model);
                db.SaveChanges();
            }
        }
        

        public async Task<List<Booking>>GetAll()
        {

            return [.. await db.bookings.ToListAsync()];
        }

        public async Task<Booking?> GetById(int id)
        {
            var data =  db.bookings.FirstOrDefault(a => a.Id== id);
             return   data;
        }

        

        public async Task<List<Booking>> Sarche(int id)
        {
            var data = db.bookings.Where(a => a.Id==id);
            return await (Task<List<Booking>>)data;
        }

        public async Task Update(Booking model)
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
