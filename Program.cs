using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspIron.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspIron
{
    /// <summary>
    /// Inicializa la solucion Asp Net
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();

            // be sure database is working
            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                // accessing the context before host start running
                var context = services.GetRequiredService<AcademyContext>();

                // be sure about db is connected
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                // if error: log
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "[An error has ocurred creating the database.]");
            }

            // now we can be sure to run the web hoster
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}