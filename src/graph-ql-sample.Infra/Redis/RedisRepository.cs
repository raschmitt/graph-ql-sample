using graph_ql_sample.Domain.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace graph_ql_sample.Infra.Redis;

public class RedisRepository<T> : IRedisRepository<T>
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _db;
    
    public RedisRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _db = redis.GetDatabase();
    }
    
    public async Task<T> GetAsync()
    {
        var redisValue = await _db.StringGetAsync("key");
        
        var result = JsonConvert.DeserializeObject<T>(redisValue);
        
        return result;
    }  
    
    public async Task<T> SetAsync(T item)
    {
        var value = JsonConvert.SerializeObject(item);
        
        await _db.StringSetAsync("key", value);
        
        return item;
    }
}