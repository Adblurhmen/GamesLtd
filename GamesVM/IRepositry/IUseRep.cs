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
        public IQueryable<User> GetAll();
        public User GetById(int id);
        public void Creat(User model);
        public void Update(User model);
        public void Delete(User model);
    }
}
