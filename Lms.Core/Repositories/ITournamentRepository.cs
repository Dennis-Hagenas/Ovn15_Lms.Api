using Lms.Core.Entities;

namespace Lms.Data.Repositories
{
    public interface ITournamentRepository
    {
        void Add(Tournament tournament);
        Task AddAsync(Tournament tournament);
        Task<bool> AnyAsync(int id);
        Task<IEnumerable<Tournament>> GetAllAsync(bool includeGames = false);
        Task<Tournament> GetAsync(string title, bool includeGames = false);
        Task<Tournament> GetAsync(int id, bool includeGames = false);
        void Remove(Tournament tournament);
        void Update(Tournament tournament);
    }
}