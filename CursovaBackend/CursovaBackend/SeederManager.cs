namespace CursovaBackend
{
    public static class SeederManager
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            Seeder.SeedAsync(serviceProvider).Wait();
            return app;
        }
    }
}
