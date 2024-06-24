using Games.Contaxt.Database;
using Games.Domain.Entity;
using GamesRep.Repositry;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Test.Serves_Test
{
    public class Room_Test
    {
        private DbContextOptions<GamesContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<GamesContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private IDbContextPool<GamesContext> GetDbContextFactoryAsync(DbContextOptions<GamesContext> options)
        {
            var mockDbFactory = new Mock<DbContextFactory<GamesContext>>();
            mockDbFactory.Setup(f => f.CreateDbContext()).Returns(() => new GamesContext(options));
            return (IDbContextPool<GamesContext>)mockDbFactory.Object;

        }

        [Fact]
        public async Task Save_ShouldAddRoom()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomRep((GamesContext)factory);
            var room = new Room { state = true, Level="VIP" };

            // Act
             service.Creat(room);

            // Assert
            using var context = new GamesContext(options);
            var fetchedRoom = await context.rooms.FirstOrDefaultAsync(a => a.state == true&& a.Level=="VIP");
            Assert.NotNull(fetchedRoom);
        }

        [Fact]
        public async Task Get_ShouldReturnvenueById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomRep((GamesContext)factory);
            var room = new Room { state = true, Level="VIP" };
             service.Creat(room);

            // Act
            var fetchedroom =  service.GetById(room.Id);

            // Assert
            Assert.NotNull(fetchedroom);
            Assert.Equal(room.Id, fetchedroom.Id);
        }

       // [Fact]
        //public async Task GetAll_ShouldReturnAllrooms()
        //{
        //    // Arrange
        //    var options = CreateNewContextOptions();
        //    var factory = GetDbContextFactoryAsync(options);
        //    var service = new RoomRep((GamesContext)factory);
        //    var room1 = new Room { state = true, Level="VIP1" };
        //    var room2 = new Room { state = true, Level="VIP2" };

        //     service.Creat(room1);
        //     service.Creat(room2);

        //    // Act
        //    var rooms =  service.GetAll();

        //    // Assert
        //    Assert.Equal(2, rooms.Count);
        //}

        [Fact]
        public async Task Delete_ShouldRemoveVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomRep((GamesContext)factory);
            var room = new Room { state = true, Level="VIP" };
            service.Creat(room);

            // Act
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         service.Delete(room);

            // Assert
            using var context = new GamesContext(options);
            var deletedroom = await context.rooms.FindAsync(room.Id);
            Assert.Null(deletedroom);
        }


        [Fact]
        public async Task Update_ShouldModifyVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new RoomRep((GamesContext)factory);
            var room = new Room { state = true, Level="VIP" };
            service.Creat(room);

            // Act
            room.Level = "VIP1";

            service.Update(room);

            // Assert
            using var context = new GamesContext(options);
            var updatedroom = await context.rooms.FindAsync(room.Id);
            Assert.Equal("VIP1", updatedroom.Level);

        }



        //[Fact]
        //public async Task GetList_ShouldReturnBookingByName()
        //{
        //    // Arrange
        //    var options = CreateNewContextOptions();
        //    var factory = GetDbContextFactoryAsync(options);
        //    var service = new RoomRep((GamesContext)factory);
        //    var room1 = new Room { state = true, Level="VIP1" ,GameId=1,VenueId=1, };
        //    var room2 = new Room { state = true, Level="VIP2", GameId=1, VenueId=1 };

        //    service.Creat(room1);
        //    service.Creat(room2);
        //    // Act
        //    var room = service.Sarche(room1.Venue.Name);

        //    // Assert
        //    Assert.Equal(2, room.Count);
        //}
    }
}
