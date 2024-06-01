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
    public class UserRep : IUseRep
    {
        private readonly GamesContext db;
        public UserRep(GamesContext db)
        {
            this.db = db;

        }
        public void Creat(User model)
        {
            var data = db.users.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data==null)
            {
                db.users.Add(model);
                db.SaveChanges();

            }
        }

        public void Delete(User model)
        {
            var data = db.users.FirstOrDefault(a => a.Id == model.Id);
            if (data==null)
            {
                db.users.Remove(model);
                db.SaveChanges();
            }
        }

        public IQueryable<User> GetAll()
        {
            var data = db.users.Select(a => a);
            return data;
        }

        public User GetById(int id)
        {
            var data = db.users.FirstOrDefault(a => a.Id== id);
            return data;
        }

        public void Update(User model)
        {
            var data = db.users.FirstOrDefault(db => db.Id == model.Id);
            if (data==null)
            {
                data.Name=model.Name;
                data.PhonNumber=model.PhonNumber;
                data.Password=model.Password;
                db.SaveChanges();

            }
        }
    }
}
