using Lms.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class UnitOfWork
    {
        private readonly LmsApiContext db;
        public TournamentRepository TournamenRepository { get; }

        public UnitOfWork(LmsApiContext db) {
            this.db = db;
            TournamenRepository = new TournamentRepository(db);
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
