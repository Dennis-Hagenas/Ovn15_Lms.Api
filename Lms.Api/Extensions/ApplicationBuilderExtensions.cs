using Lms.Data.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lms.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<LmsApiContext>();

                var config = serviceProvider.GetRequiredService<IConfiguration>();

                try
                {
                    await SeedData.InitAsync(db, serviceProvider);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
