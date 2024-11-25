using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotApiGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Services.AddOcelot();

            var app = builder.Build();
            await app.UseOcelot();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
