using Lms.Core.Entities;

namespace Lms.Data.Repositories
{
    public interface IGameRepository
    {
        void Add(Game game);
        Task<bool> AnyAsync(int id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetAsync(int id);
        void Remove(Game game);
        void Update(Game game);
    }
}