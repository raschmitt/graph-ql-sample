namespace graph_ql_sample.Register;

public static class HealthChecksRegister
{
    public static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddRedis(configuration.GetConnectionString("Redis"));
    }
}