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
    public class VenueRep : IVenueRep
    {
        private readonly GamesContext db;
        public VenueRep(GamesContext db) 
        {
            this.db = db;

        }
        public async Task Creat(Venue model)
        {
            var data = db.venues.Where(a => a.Id == model.Id);
            //var data = db.venues.FirstOrDefault(a => a.Id == model.Id);

            if (data==null )
            {
                db.venues.Add(model);
                db.SaveChanges();

            }
        }

        public async Task Delete(Venue model)
        {
            var data = db.venues.FirstOrDefault(a=> a.Id == model.Id);
            if(data==null ) 
            {
                db.venues.Remove(model);
                db.SaveChanges();
            }
        }

        public async Task<List<Venue>> GetAll()
        {
            //var data =  db.venues.Select(a => a);
            return [..await db.venues.ToListAsync()];
        }

        public async Task<Venue> GetById(int id)
        {
            var data = db.venues.FirstOrDefault(a=>a.Id== id);
            return data;
        }

        public async Task<List<Venue>> Sarche(string Name)
        {
           var data = db.venues.Where(a=>a.Name.Contains(Name));
           
            return await (Task<List<Venue>>)data; ;
        }

        public async Task Update(Venue model)
        {
           var data = db.venues.FirstOrDefault(db=> db.Id == model.Id);
            if ( data==null )
            {
                data.Name=model.Name;
                data.Location=model.Location;

                // data.Rooms=model.Rooms;
                db.SaveChanges();

            }
        }
    }
}
