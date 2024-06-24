using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Contaxt.Database;
using Games.Domain.Entity;
using GamesRep.Repositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;


namespace Game.Test.Serves_Test
{
    public class Game_Test
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
            var service = new GameRep((GamesContext)factory);
            var game = new Games.Domain.Entity.Game { Type = "Game1" };

            // Act
            await service.Creat(game);

            // Assert
            using var context = new GamesContext(options);
            var fetchedgame = await context.games.FirstOrDefaultAsync(a => a.Type == "Game1");
            Assert.NotNull(fetchedgame);
        }

        [Fact]
        public async Task Get_ShouldReturngameById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new GameRep((GamesContext)factory);
            var game = new Games.Domain.Entity.Game { Type = "Game1" };
            await service.Creat(game);

            // Act
            var fetchedgame = await service.GetById(game.Id);

            // Assert
            Assert.NotNull(fetchedgame);
            Assert.Equal(game.Type, fetchedgame.Type);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllGames()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new GameRep((GamesContext)factory);
            await service.Creat(new Games.Domain.Entity.Game { Type = "Game1" });
            await service.Creat(new Games.Domain.Entity.Game { Type = "Game2" });

            // Act
            var Games = await service.GetAll();

            // Assert
            Assert.Equal(2, Games.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveGame()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new GameRep((GamesContext)factory);
            var game = new Games.Domain.Entity.Game { Type = "Game1" };
            await service.Creat(game);

            // Act
            await service.Delete(game);

            // Assert
            using var context = new GamesContext(options);
            var deletedGame = await context.games.FindAsync(game.Id);
            Assert.Null(deletedGame);
        }


        [Fact]
        public async Task Update_ShouldModifyGame()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new GameRep((GamesContext)factory);
            var game = new Games.Domain.Entity.Game { Type = "Game1" };
            await service.Creat(game);

            // Act
            game.Type = "Updated Game";
           
            await service.Update(game);

            // Assert
            using var context = new GamesContext(options);
            var updatedGame = await context.games.FindAsync(game.Id);
            Assert.Equal("Updated Game", updatedGame.Type);
           
        }


    }
}
