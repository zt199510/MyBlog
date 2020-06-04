using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Acme.BookStore.Hosting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(builder =>
                       {
                           builder.UseIISIntegration()
                                  .UseStartup<Startup>();
                       }).UseAutofac().Build().RunAsync();
        }

       
    }
}
