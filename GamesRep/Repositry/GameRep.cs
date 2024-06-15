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
    public class GameRep : IGameRep
    {

        private readonly GamesContext db;
        public GameRep(GamesContext db)
        {
            this.db = db;

        }

        public async Task Creat(Game model)
        {

            var data = db.games.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data==null)
            {
                db.games.Add(model);
                db.SaveChanges();

            }

        }

        public async Task Delete(Game model)
        {
            var data = db.games.FirstOrDefault(a => a.Id == model.Id);
            if (data==null)
            {
                db.games.Remove(model);
                db.SaveChanges();
            }

        }

        public async Task <Game> GetById(int id)
        {
            var data = db.games.FirstOrDefault(a => a.Id==id);
            return  data;

        }
    }
}
