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
    public class TournamentRepository
    {
        private readonly LmsApiContext db;

        public TournamentRepository(LmsApiContext db) {
            this.db = db;
        }

        public async Task<IEnumerable<Tournament>> GetAsync()
        {
            return await db.Tournament.ToListAsync();
        }
    }
}
