namespace PlatformService.Data
{
    using PlatformService.Models;
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data");

                context.Platforms.AddRange(
                    new Platform() { Name = "DOT NET ", Cost = "Free", Publisher = "Microsoft" },
                    new Platform() { Name = "SQL Server express ", Cost = "Free", Publisher = "Microsoft" },
                    new Platform() { Name = "Kubernetes ", Cost = "Free", Publisher = "Cloud native computing company" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data");
            }
        }
    }
}
