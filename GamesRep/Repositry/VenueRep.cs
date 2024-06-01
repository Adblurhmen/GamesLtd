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
        public void Creat(Venue model)
        {
            var data = db.venues.Where(a => a.Id == model.Id);
            //var data = db.venues.FirstOrDefault(a => a.Id == model.Id);

            if (data==null )
            {
                db.venues.Add(model);
                db.SaveChanges();

            }
        }

        public void Delete(Venue model)
        {
            var data = db.venues.FirstOrDefault(a=> a.Id == model.Id);
            if(data==null ) 
            {
                db.venues.Remove(model);
                db.SaveChanges();
            }
        }

        public IQueryable<Venue> GetAll()
        {
            var data = db.venues.Select(a => a);
            return data;
        }

        public Venue GetById(int id)
        {
            var data = db.venues.FirstOrDefault(a=>a.Id== id);
            return data;
        }

        public IQueryable<Venue> Sarche(string Name)
        {
           var data = db.venues.Where(a=>a.Name.Contains(Name));
            return data;
        }

        public void Update(Venue model)
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
