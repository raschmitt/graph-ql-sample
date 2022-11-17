namespace graph_ql_sample.Domain.Interfaces;

public interface IRedisRepository<T>
{
    Task<T> GetAsync();
    Task<T> SetAsync(T item);
}