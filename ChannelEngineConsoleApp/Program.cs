using ChannelEngineShared;
using ChannelEngineShared.Configuration;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedLibrary;
using System.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var start = DateTime.Now;
        var host = CreateDefaultBuilder().Build();
        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        IConfiguration configuration = configurationBuilder.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

        //setup DI
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ISharedManager, SharedManager>()
            .AddMediatR((typeof(Program)))
            .Configure<ChannelEngineSharedConfigOptions>(configuration.GetSection(ChannelEngineSharedConfigOptions.ServiceConfiguration))
            .BuildServiceProvider();

        var workerInstance = serviceProvider.GetRequiredService<ISharedManager>();

        var orders = workerInstance.FetchAllInProcessOrders();
        var top5ProductsList = workerInstance.Top5ProductsSoldList(orders);

        if (top5ProductsList != null)
        {
            Console.WriteLine($"Top 5 products");
            foreach (var product in top5ProductsList)
            {
                Console.WriteLine($"Product - {product.Description} GTIN - {product.Gtin} Quanitity - {product.Quantity} MerchantProductNo - {product.MerchantProductNo}");
               
            }
        }
        string merchantProductNo;
        string stock;
        Console.Write("Enter merchantProductNo: ");
        merchantProductNo = Console.ReadLine();
        Console.Write("Enter Stock: ");
        stock = Console.ReadLine();
        if(workerInstance.UpdateProductStock(merchantProductNo, Convert.ToInt32(stock)))
            Console.WriteLine($"Your product {merchantProductNo} stock updated");

        Console.WriteLine($"Start: {start}");
        Console.WriteLine($"End: {DateTime.Now}");
    }
    static IHostBuilder CreateDefaultBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(app =>
            {
                app.AddJsonFile("appsettings.json");
            })
            .ConfigureServices(services =>
            {
                services.AddSingleton<ISharedManager, SharedManager>();
            });
    }
}