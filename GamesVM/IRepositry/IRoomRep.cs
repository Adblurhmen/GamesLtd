using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamsIRep.IRepositry
{
    public interface IRoomRep
    {
        public IQueryable<Room> GetAll();
        public Room GetById(int id);
        public IQueryable<Room> Sarche(string Name, string type);
        public void Creat(Room model);
        public void Update(Room model);
        public void Delete(Room model);
    }
}
