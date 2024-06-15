using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public bool state { get; set; }
        //==================================
        [ForeignKey("GameId")]
        public int  GameId { get; set; }
        public Game Game { get; set; }
        [ForeignKey("VenueId")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public List<User> Users { get; set; }

    }
}
