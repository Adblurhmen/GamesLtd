using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public int NumberHours { get; set; }
        public string Prise { get; set; }

        public int UserId { get; set; }
        public int RoomId { get; set; }
         
       

        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }

    }
}
