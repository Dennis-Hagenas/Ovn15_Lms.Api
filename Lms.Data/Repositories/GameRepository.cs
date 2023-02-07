using Lms.Core.Entities;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
 
namespace Lms.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly LmsApiContext db;

        public GameRepository(LmsApiContext db)
        {
            this.db = db;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await db.Game.ToListAsync();
        }

        public async Task<Game> GetAsync(int id)
        {
            return db.Game.FirstOrDefault(g => g.Id == id);
        }

        public Task<bool> AnyAsync(int id)
        {
            return db.Game.AnyAsync(g => g.Id == id);
        }

        public void Add(Game game)
        {
            db.Game.Add(game);
        }
        public void Update(Game game)
        {
            db.Game.Update(game);
        }
        public void Remove(Game game)
        {
            db.Remove(game);
        }
    }
}
