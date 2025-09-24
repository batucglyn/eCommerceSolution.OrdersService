using eCommerce.OrdersMicroervice.DataAccessLayer.Repositories;
using eCommerce.OrdersMicroervice.DataAccessLayer.RepositoryContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.OrdersMicroservice.DataAccessLayer;

public static class DependencyInjection
{

    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {

        //TO DO: Add data access layer services into the IoC container
        string connectionStringTemplate = configuration.GetConnectionString("MongoDB")!;
        string connectionString = connectionStringTemplate
          .Replace("$MONGO_HOST", Environment.GetEnvironmentVariable("MONGODB_HOST"))
          .Replace("$MONGO_PORT", Environment.GetEnvironmentVariable("MONGODB_PORT"));

        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

        services.AddScoped<IMongoDatabase>(provider =>
        {
            IMongoClient client = provider.GetRequiredService<IMongoClient>();
            return client.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE"));
        });


        services.AddScoped<IOrderRepository, OrdersRepository>();
        return services;
    }

}

