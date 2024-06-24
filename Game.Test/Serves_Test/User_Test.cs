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

namespace Game.Test.Serves_Test
{
    public class User_Test
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
        public async Task Save_ShouldAddUser()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new UserRep((GamesContext)factory);
            var user = new User{ Name = "Name1" };

            // Act
            await service.Creat(user);

            // Assert
            using var context = new GamesContext(options);
            var fetchedname = await context.users.FirstOrDefaultAsync(a => a.Name == "Name1");
            Assert.NotNull(fetchedname);
        }

        [Fact]
        public async Task Get_ShouldReturnnameById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new UserRep((GamesContext)factory);
            var user = new User { Name = "Name1" };
            await service.Creat(user);

            // Act
            var fetcheduser = await service.GetById(user.Id);

            // Assert
            Assert.NotNull(fetcheduser);
            Assert.Equal(user.Name, fetcheduser.Name);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllusers()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new UserRep((GamesContext)factory);
            var user1 = new User { Name = "Name1" };
            var user2 = new User { Name = "Name2" };

            // Act
            var users = await service.GetAll();

            // Assert
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveUser()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new UserRep((GamesContext)factory);
            var user1 = new User { Name = "Name1" };
            await service.Creat(user1);

            // Act
            await service.Delete(user1);

            // Assert
            using var context = new GamesContext(options);
            var deletedUsers = await context.users.FindAsync(user1.Id);
            Assert.Null(deletedUsers);
        }


        [Fact]
        public async Task Update_ShouldModifyGame()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new UserRep((GamesContext)factory);
            var user1 = new User { Name = "Name1" };
            await service.Creat(user1);

            // Act
            user1.Name = "Updated User";

            await service.Update(user1);

            // Assert
            using var context = new GamesContext(options);
            var updatedUser = await context.users.FindAsync(user1.Id);
            Assert.Equal("Updated User", updatedUser.Name);

        }

    }
}
