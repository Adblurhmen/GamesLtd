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
        public Game GetById(int id);
        public void Creat(Game model);
        public void Delete(Game model);
    }
}
