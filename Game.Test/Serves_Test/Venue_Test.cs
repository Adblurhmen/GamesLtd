using Games.Contaxt.Database;
using GamesRep.Repositry;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Domain.Entity;
using GamsIRep.IRepositry;

namespace Game.Test.Serves_Test
{
    public class Venue_Test
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
            var service = new VenueRep((GamesContext)factory);
            var venue = new Venue { Name = "venue1" };

            // Act
            await service.Creat(venue);

            // Assert
            using var context = new GamesContext(options);
            var fetchedvenue = await context.venues.FirstOrDefaultAsync(a => a.Name == "venue1");
            Assert.NotNull(fetchedvenue);
        }

        [Fact]
        public async Task Get_ShouldReturnvenueById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new VenueRep((GamesContext)factory);
            var venue = new Venue { Name = "venue2", Location="123abc" };
            await service.Creat(venue);

            // Act
            var fetchedvenue = await service.GetById(venue.Id);

            // Assert
            Assert.NotNull(fetchedvenue);
            Assert.Equal(venue.Name, fetchedvenue.Name);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllvenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new VenueRep((GamesContext)factory);
            var venue1 =  new Venue { Name = "venue1", Location="123abc" };
            var venue2 = new Venue { Name = "venue2", Location="123abc" };

            await service.Creat(venue1);
            await service.Creat(venue2);

            // Act
            var venue = await service.GetAll();

            // Assert
            Assert.Equal(2, venue.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new VenueRep((GamesContext)factory);
            var venue = new Venue { Name = "venue1", Location="123abc" };
            await service.Creat(venue);

            // Act
            await service.Delete(venue);

            // Assert
            using var context = new GamesContext(options);
            var deletedvenue = await context.venues.FindAsync(venue.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new VenueRep((GamesContext)factory);
            var venue = new Venue { Name = "venue1", Location="123abc" };
            await service.Creat(venue);

            // Act
            venue.Name = "Updated Venue";

            await service.Update(venue);

            // Assert
            using var context = new GamesContext(options);
            var updatedvenue = await context.venues.FindAsync(venue.Id);
            Assert.Equal("Updated Venue", updatedvenue.Name);

        }



        [Fact]
        public async Task GetList_ShouldReturnAuthorsByName()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new VenueRep((GamesContext)factory);
            var venue1 = new Venue { Name = "venue1", Location="123abc" };
            var venue2 = new Venue { Name = "venue2", Location="123abc" };

            await service.Creat(venue1);
            await service.Creat(venue2);
            // Act
            var venues = await service.Sarche("venue");

            // Assert
            Assert.Equal(2, venues.Count);
        }

       



    }
}
