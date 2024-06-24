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
    public class Booking_Test
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
        public async Task Save_ShouldAddGame()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new BookingRep((GamesContext)factory);
            var booking = new Booking { NumberHours = 2,Prise="30" };

            // Act
            await service.Creat(booking);

            // Assert
            using var context = new GamesContext(options);
            var fetchedvenue = await context.bookings.FirstOrDefaultAsync(a => a.NumberHours == 2&& a.Prise=="30");
            Assert.NotNull(fetchedvenue);
        }

        [Fact]
        public async Task Get_ShouldReturnvenueById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new BookingRep((GamesContext)factory);
            var booking = new Booking { NumberHours = 2, Prise="30" };
            await service.Creat(booking);

            // Act
            var fetchedbooking = await service.GetById(booking.Id);

            // Assert
            Assert.NotNull(fetchedbooking);
            Assert.Equal(booking.Id, fetchedbooking.Id);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllvenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new BookingRep((GamesContext)factory);
            var booking1 = new Booking { NumberHours = 1, Prise="10" };
            var booking2 = new Booking { NumberHours = 2, Prise="20" };

            await service.Creat(booking1);
            await service.Creat(booking2);

            // Act
            var booking = await service.GetAll();

            // Assert
            Assert.Equal(2, booking.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new BookingRep((GamesContext)factory);
            var booking = new Booking { NumberHours = 2, Prise="30" };
            await service.Creat(booking);

            // Act
            await service.Delete(booking);

            // Assert
            using var context = new GamesContext(options);
            var deletedvenue = await context.bookings.FindAsync(booking.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new BookingRep((GamesContext)factory);
            var booking = new Booking { NumberHours = 2, Prise="30" };
            await service.Creat(booking);

            // Act
            booking.NumberHours = 2;

            await service.Update(booking);

            // Assert
            using var context = new GamesContext(options);
            var updatedbooking = await context.bookings.FindAsync(booking.Id);
            Assert.Equal(2, updatedbooking.NumberHours);

        }



        [Fact]
        public async Task GetList_ShouldReturnBookingByName()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new BookingRep((GamesContext)factory);
            var booking1 = new Booking { NumberHours = 1, Prise="20" ,RoomId=3,UserId=4};
            var booking2 = new Booking { NumberHours = 2, Prise="30", RoomId=3, UserId=4 };

            await service.Creat(booking1);
            await service.Creat(booking2);
            // Act
            var booking = await service.Sarche(booking1);

            // Assert
            Assert.Equal(2, booking.Count);
        }

    }
}
