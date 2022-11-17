using graph_ql_sample.Domain.Entities;
using graph_ql_sample.Domain.Interfaces;
using graph_ql_sample.Infra.Redis;
using StackExchange.Redis;

namespace graph_ql_sample.Register;

public static class RedisRegister
{
    public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
        
        services.AddSingleton<IConnectionMultiplexer>(multiplexer);

        services.AddTransient<IRedisRepository<Book>, RedisRepository<Book>>();
    }
}