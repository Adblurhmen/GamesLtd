using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamsIRep.IRepositry
{
    public interface IGameRep
    {
        public Task<Game> GetById(int id);
        public Task Creat(Game model);
        public Task Delete(Game model);
        public  Task<List<Game>> GetAll();
        public  Task Update(Game model);
    }
}
