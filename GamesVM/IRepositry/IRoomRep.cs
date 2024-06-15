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
        public Task<List<Room>> GetAll();
        public Task<Room> GetById(int id);
        public Task<List<Room>> Sarche(string Name, string type);
        public Task Creat(Room model);
        public Task Update(Room model);
        public Task Delete(Room model);
    }
}
