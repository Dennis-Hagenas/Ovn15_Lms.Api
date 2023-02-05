using Lms.Core.Entities;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly LmsApiContext db;

        public TournamentRepository(LmsApiContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync(bool includeGames)
        {
            return includeGames ? await db.Tournament.Include(c => c.Games).ToListAsync()
                : await db.Tournament.ToListAsync();
        }

        public async Task<Tournament> GetAsync(string title, bool includeGames)
        {
            var query = db.Tournament
                .AsQueryable();

            if (includeGames)
            {
                query = query.Include(g => g.Games);
            }

            return 
                 await query.FirstOrDefaultAsync(g => g.Title == title);
        }


        public async Task<Tournament> GetAsync(int id)
        {
            return db.Tournament.FirstOrDefault(g => g.Id == id);
        }

        public Task<bool> AnyAsync(int id)
        {
            return db.Tournament.AnyAsync(g => g.Id == id);
        }

        public void Add(Tournament tournament)
        {
            db.Add(tournament);
        }
        public void Update(Tournament tournament)
        {
            db.Tournament.Update(tournament);
        }
        public void Remove(Tournament tournament)
        {
            db.Remove(tournament);
        }
    }
}
