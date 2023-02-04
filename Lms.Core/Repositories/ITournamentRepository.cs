using Lms.Core.Entities;

namespace Lms.Data.Repositories
{
    public interface ITournamentRepository
    {
        void Add(Tournament tournament);
        Task<bool> AnyAsync(int id);
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task<Tournament> GetAsync(int id);
        void Remove(Tournament tournament);
        void Update(Tournament tournament);
    }
}