//////////////////////////
// generated Program.cs //
/////////////////////////
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Context;
using System.Reflection;

namespace startup
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .ConfigureServices((hostContext, services) =>
                {
                    //required if you are using entity framework
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Name=SqlServerDB"));
                })
                .RunConsoleAsync();
        }
    }
}
