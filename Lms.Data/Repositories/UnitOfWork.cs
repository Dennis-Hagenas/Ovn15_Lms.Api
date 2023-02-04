﻿using Lms.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LmsApiContext db;
        public ITournamentRepository TournamenRepository { get; }
        public IGameRepository GameRepository { get; }

        public UnitOfWork(LmsApiContext db)
        {
            this.db = db;
            TournamenRepository = new TournamentRepository(db);
            GameRepository = new GameRepository(db);
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
