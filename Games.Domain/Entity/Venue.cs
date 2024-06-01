﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Entity
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //public string Phon {  get; set; }

        public ICollection<Room> Rooms { get; set; }



    }
}
