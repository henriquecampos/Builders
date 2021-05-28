using Builders.Application.Common.Interfaces;
using Builders.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Builders.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

            services.AddScoped<IMongoClient>(x =>
            {
                var connectionString = configuration.GetConnectionString("MongoDb");
                return new MongoClient(connectionString);
            });

            services.AddScoped<IMongoDatabase>(x => x.GetRequiredService<IMongoClient>().GetDatabase("tree"));
            services.AddTransient<IBinaryTreeRepository, BinaryTreeRepository>();

            return services;
        }
    }
}