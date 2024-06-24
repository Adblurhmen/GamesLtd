using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamsIRep.IRepositry
{
    public interface IUseRep
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task Creat(User model);
        public Task Update(User model);
        public Task Delete(User model);
    }
}
