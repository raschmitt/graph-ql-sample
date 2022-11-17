using graph_ql_sample.Domain.Entities;
using graph_ql_sample.Domain.Interfaces;

namespace graph_ql_sample.GraphQL.Queries;

public class BookQuery
{
    private readonly IRedisRepository<Book> _redisRepository;

    public BookQuery(IRedisRepository<Book> redisRepository)
    {
        _redisRepository = redisRepository;
    }
    
    public async Task<Book> GetBook()
    {
        return await _redisRepository.GetAsync();
    }
}