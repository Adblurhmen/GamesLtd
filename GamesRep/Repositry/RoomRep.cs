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
    public class RoomRep : IRoomRep
    {
        private readonly GamesContext db;
        public RoomRep(GamesContext db)
        {
            this.db = db;

        }
        public void Creat(Room model)
        {
            var data = db.rooms.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data==null)
            {
                db.rooms.Add(model);
                db.SaveChanges();

            }
        }

        public void Delete(Room model)
        {
            var data = db.rooms.FirstOrDefault(a => a.Id == model.Id);
            if (data==null)
            {
                db.rooms.Remove(model);
                db.SaveChanges();
            }
        }

        public IQueryable<Room> GetAll()
        {
            var data = db.rooms.Select(a => a);
            return data;
        }

        public Room GetById(int id)
        {
            var data = db.rooms.FirstOrDefault(a => a.Id== id);
            return data;
        }

        public IQueryable<Room> Sarche(string Name, string type)
        {
            var data = db.rooms.Where(a => a.Game.Type.Contains(type)   ||  a.Venue.Name.Contains(Name));
            return data;
        }

        public void Update(Room model)
        {
            var data = db.rooms.FirstOrDefault(db => db.Id == model.Id);
            if (data==null)
            {
                data.Level=model.Level;
                data.state=model.state;
                data.Game.Type=model.Game.Type;
                db.SaveChanges();

            }
        }
    }
}
