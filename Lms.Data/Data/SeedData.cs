using Bogus;
using Lms.Core.Entities;
using Lms.Data.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Lms.Api.Extensions
{
    public class SeedData
    {
        private static LmsApiContext db = default!;
        private static IServiceProvider serviceProvider = default!;

        public static async Task InitAsync(LmsApiContext db, IServiceProvider serviceProvider)
        {
            //if (context is null) throw new ArgumentNullException(nameof(context));
            //db = context;

            //ArgumentNullException.ThrowIfNull(nameof(services));
            //ArgumentNullException.ThrowIfNull(adminPW, nameof(adminPW));
            SeedData.db = db;
            SeedData.serviceProvider = serviceProvider;

            List<Tournament> tournaments = AddTournaments(20);
            db.Tournament.AddRange(tournaments);
            await db.SaveChangesAsync();
            tournaments =  db.Tournament.ToList();

            List<Game> games = AddGames(tournaments, 40);
            db.Game.AddRange(games);
            await db.SaveChangesAsync();

        }

        private static List<Game> AddGames(List<Tournament> tournaments, int v)
        {
            Tournament[] tmnts = tournaments.ToArray();
            List<Game> result = new List<Game>();

            for(int i =0; i < v; i++)
            {
                Faker f = new Faker();
                Tournament t = tmnts[f.Random.Int(0,tmnts.Length-1)];
                Game game = new Game()
                {
                    Time = t.StartDate?.AddHours(f.Random.Int(0,23)),
                    Title= f.Commerce.ProductAdjective().ToString() + " " + f.Hacker.IngVerb(),
                    TournamentId = t.Id
                };
                t.Games.Add(game);
                result.Add(game);
            }
            return result;
        }

        private static List<Tournament> AddTournaments(int nrOfTournaments)
        {
            var faker = new Faker<Tournament>("sv").Rules((f, g) =>
            {
                g.Title = $"{f.Commerce.ProductAdjective()}  Tournament";
                g.StartDate = DateTime.Now.AddDays(f.Random.Int(0, 20));
            });
            return faker.Generate(nrOfTournaments);
        }

    }
}