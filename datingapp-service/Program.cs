using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace datingapp_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //public static void Main(string[] args)
            //{
            //    var host = CreateHostBuilder(args).Build();  //Taken Off Run Method till we insert the data into database.
            //    using (var scope = host.Services.CreateScope())
            //    {
            //        var services = scope.ServiceProvider;
            //        try
            //        {
            //            var context = services.GetRequiredService<DatingAppDBContext>();
            //            context.Database.Migrate();
            //            SeedData.SeedUsers(context);
            //        }
            //        catch (Exception Ex)
            //        {
            //            var logger = services.GetRequiredService<ILogger<Program>>();
            //            logger.LogError(Ex, "An error has occured during migration");
            //        }
            //    }
            //    host.Run();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
