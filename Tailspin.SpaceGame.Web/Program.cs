using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TailSpin.SpaceGame.Web.DB;

namespace TailSpin.SpaceGame.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Initialize the database
            var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TailspinContext>();
                if (db.Database.EnsureCreated())
                {
                    SeedData.Initialize(db);
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options => {
                    options.Listen(System.Net.IPAddress.Loopback, 5000);
                })
                .UseStartup<Startup>();
    }
}
