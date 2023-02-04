using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lms.Data
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<LmsApiContext>
    {
       public LmsApiContext  CreateDbContext(string[] args)
        {
                var options = new DbContextOptionsBuilder<LmsApiContext>();
                options.UseSqlServer("Not used here");

                return new LmsApiContext(options.Options);
         }
    }
}

