using Games.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Contaxt.Database
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> opt) : base(opt)
        {

        }

        public DbSet<Venue> venues { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Game> games { get; set; }
        public DbSet<Booking> bookings { get; set; }


    }
}
