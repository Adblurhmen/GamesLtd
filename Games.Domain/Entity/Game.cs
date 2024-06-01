using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Entity
{
    public class Game
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Room> Rooms{ get; set; }
    }
}
