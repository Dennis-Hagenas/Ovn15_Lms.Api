using Lms.Data.Data;
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
    }
}
